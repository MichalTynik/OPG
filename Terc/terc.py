import pygame
import sys
import random
import time
import math
import mysql.connector
from mysql.connector import Error

pygame.init()

width, height = 1000, 1000
screen = pygame.display.set_mode((width, height))
pygame.display.set_caption("Simulacia strelba na Terc Pygame -4SB2-BabjarcikD")
icon = pygame.image.load('terclogo.png') 
pygame.display.set_icon(icon)

background_color = (227, 230, 230)
black = (0, 0, 0)
white = (255, 255, 255)
red = (255, 0, 0)
gray = (200, 200, 200)
slider_color = (100, 100, 255)
green = (0, 128, 0)
blue = (0, 0, 255)

target_image = pygame.image.load("terc.png")
target_image = pygame.transform.scale(target_image, (500, 500))
crosshair_image = pygame.image.load("cross1.png")
crosshair_image = pygame.transform.scale(crosshair_image, (50, 50))

target_rect = target_image.get_rect(center=(width // 2, height // 2 - 150))
crosshair_rect = crosshair_image.get_rect()

wind = 0
discomfort = 0
shots = 0
max_shots = 5
results = []
simulation_results = []
manual_shots = []
last_move_time = time.time()
shoot_cooldown = 0.5
last_shot_time = 0
message = ""
message_time = 0
user_name = ""
active_input = False
cursor_visible = False
cursor_timer = 0
cursor_blink_interval = 0.5
current_session_id = None
session_shots_count = 0
game_active = False
show_stats = False
stats = []
max_target_radius = 250  # pre 0

db_config = {
    'host': 'localhost',
    'user': 'root',
    'password': '',
    'database': 'shooting_game_db'
}


slider_width = 250
slider_height = 15
menu_rect = pygame.Rect(100, height - 350, width - 200, 300)
name_input_rect = pygame.Rect(width // 2 - 150, height // 2 - 450, 300, 40)
delete_name_rect = pygame.Rect(width // 2 + 160, height // 2 - 450, 40, 40)
wind_slider_rect = pygame.Rect(width // 2 - slider_width // 2, height - 310, slider_width, slider_height)
discomfort_slider_rect = pygame.Rect(width // 2 - slider_width // 2, height - 250, slider_width, slider_height)
input_rect = pygame.Rect(width // 2 - 50, height - 220, 100, 40)
up_arrow_rect = pygame.Rect(width // 2 + 60, height - 220, 20, 20)
down_arrow_rect = pygame.Rect(width // 2 - 80, height - 220, 20, 20)
button_rect = pygame.Rect(width // 2 - 100, height - 170, 200, 50)
test_uniform_button_rect = pygame.Rect(width // 2 - 220, height - 100, 210, 40)
test_normal_button_rect = pygame.Rect(width // 2 + 40, height - 100, 210, 40)
message_rect = pygame.Rect(width // 2 - 200, height - 390, 400, 30)
stats_button_rect = pygame.Rect(width - 200, 20, 130, 40)
stats_rect = pygame.Rect(width // 2 - 250, height // 2 - 200, 500, 400)

font = pygame.font.Font(None, 36)
small_font = pygame.font.Font(None, 24)
stats_font = pygame.font.Font(None, 22)

def create_database_connection():
    try:
        return mysql.connector.connect(**db_config)
    except Error as e:
        print(f"Chyba pri pripojeni k MySQL: {e}")
        return None

def initialize_database():
    connection = create_database_connection()
    if connection:
        try:
            cursor = connection.cursor()
            cursor.execute("CREATE DATABASE IF NOT EXISTS shooting_game_db")
            cursor.execute("USE shooting_game_db")
            
            cursor.execute("""
                CREATE TABLE IF NOT EXISTS players (
                    player_id INT AUTO_INCREMENT PRIMARY KEY,
                    player_name VARCHAR(50) NOT NULL,
                    registration_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                )
            """)
            
            cursor.execute("""
                CREATE TABLE IF NOT EXISTS shooting_sessions (
                    session_id INT AUTO_INCREMENT PRIMARY KEY,
                    player_id INT NOT NULL,
                    session_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                    wind_level INT,
                    discomfort_level INT,
                    average_score FLOAT,
                    best_score INT,
                    FOREIGN KEY (player_id) REFERENCES players(player_id)
                )
            """)
            
            cursor.execute("""
                CREATE TABLE IF NOT EXISTS shots (
                    shot_id INT AUTO_INCREMENT PRIMARY KEY,
                    session_id INT NOT NULL,
                    shot_number INT NOT NULL,
                    x_coord INT NOT NULL,
                    y_coord INT NOT NULL,
                    distance_from_center INT NOT NULL,
                    points FLOAT NOT NULL,
                    FOREIGN KEY (session_id) REFERENCES shooting_sessions(session_id)
                )
            """)
            
            connection.commit()
        except Error as e:
            print(f"Chyba pri inicializacii databazy: {e}")
        finally:
            if connection.is_connected():
                cursor.close()
                connection.close()

def calculate_points(distance):
    """Calculate points based on distance from center (100 at center, 0 at max radius)"""
    return max(0, 100 - (distance / max_target_radius * 100))

def calculate_stats(shots_data):
    if not shots_data:
        return None
    
    distances = [math.sqrt((x - target_rect.centerx)**2 + (y - target_rect.centery)**2) for x, y in shots_data]
    points = [calculate_points(d) for d in distances]
    average = sum(points) / len(points) if points else 0
    best = max(points) if points else 0
    
    return {
        'average': average,
        'best': best,
        'count': len(shots_data),
        'points': points,
        'distances': distances
    }

def save_results_to_db(player_name, wind, discomfort, shots_data, is_new_session=False):
    global current_session_id, session_shots_count
    
    connection = create_database_connection()
    if not connection:
        return False
    
    try:
        cursor = connection.cursor()
        
        cursor.execute("SELECT player_id FROM players WHERE player_name = %s", (player_name,))
        result = cursor.fetchone()
        
        if result:
            player_id = result[0]
        else:
            cursor.execute("INSERT INTO players (player_name) VALUES (%s)", (player_name,))
            player_id = cursor.lastrowid
        
        stats = calculate_stats(shots_data)
        
        if is_new_session or current_session_id is None:
            cursor.execute("""
                INSERT INTO shooting_sessions 
                (player_id, wind_level, discomfort_level, average_score, best_score)
                VALUES (%s, %s, %s, %s, %s)
            """, (player_id, wind, discomfort, stats['average'], stats['best']))
            current_session_id = cursor.lastrowid
            session_shots_count = 0
            connection.commit()
        
        for shot in shots_data:
            session_shots_count += 1
            x, y = shot
            distance = math.sqrt((x - target_rect.centerx)**2 + (y - target_rect.centery)**2)
            points = calculate_points(distance)
            cursor.execute("""
                INSERT INTO shots (session_id, shot_number, x_coord, y_coord, distance_from_center, points)
                VALUES (%s, %s, %s, %s, %s, %s)
            """, (current_session_id, session_shots_count, x, y, int(distance), points))
        
        connection.commit()
        return True
    except Error as e:
        print(f"Chyba pri ukladani do databazy: {e}")
        connection.rollback()
        return False
    finally:
        if connection.is_connected():
            cursor.close()
            connection.close()

def load_stats_from_db():
    connection = create_database_connection()
    if not connection:
        return []
    
    try:
        cursor = connection.cursor(dictionary=True)
        cursor.execute("""
            SELECT s.session_id, p.player_name, s.session_date, 
                   s.wind_level, s.discomfort_level, 
                   IFNULL(s.average_score, 0) as average_score, 
                   IFNULL(s.best_score, 0) as best_score
            FROM shooting_sessions s
            JOIN players p ON s.player_id = p.player_id
            ORDER BY s.session_date DESC
            LIMIT 10
        """)
        return cursor.fetchall()
    except Error as e:
        print(f"Chyba pri nacitani statistik z databazy: {e}")
        return []
    finally:
        if connection.is_connected():
            cursor.close()
            connection.close()

initialize_database()

def draw_text(text, x, y, color=black, font=font):
    text_surface = font.render(text, True, color)
    text_rect = text_surface.get_rect(center=(x, y))
    screen.blit(text_surface, text_rect)

def draw_slider(rect, value, max_value):
    pygame.draw.rect(screen, gray, rect)
    fill_width = rect.width * (value / max_value)
    pygame.draw.rect(screen, slider_color, (rect.x, rect.y, fill_width, rect.height))

def reset_game():
    global shots, results, manual_shots, message, message_time
    global current_session_id, session_shots_count, game_active, last_shot_time
    shots = 0
    results = []
    manual_shots = []
    current_session_id = None
    session_shots_count = 0
    game_active = False
    last_shot_time = 0
    message = "Hra bola resetovana"
    message_time = time.time()

def start_game():
    global game_active, simulation_results
    if user_name:
        game_active = True
        simulation_results = []
        return True
    else:
        return False

def get_wind_description(value):
    descriptions = {
        0: "Bezvetrie", 1: "Slaby vietor", 2: "Slaby vietor", 3: "Slaby vietor",
        4: "Mierny vietor", 5: "Mierny vietor", 6: "Mierny vietor", 
        7: "Silny vietor", 8: "Silny vietor", 9: "Narazovy vietor", 10: "Narazovy vietor"
    }
    return descriptions.get(value, "Neznamy")

def get_discomfort_description(value):
    descriptions = {
        0: "Strelba v klude", 1: "Po behu (biatlon)", 2: "Po behu (biatlon)", 
        3: "Po behu (biatlon)", 4: "Strelba v lahu", 5: "Strelba v lahu", 
        6: "Strelba v lahu", 7: "Strelba v poklaku", 8: "Strelba v poklaku", 
        9: "Strelba v stoji", 10: "Strelba v stoji"
    }
    return descriptions.get(value, "Neznamy")

def apply_wind_and_discomfort(x, y, is_shot=False):
    if is_shot:
        wind_effect = wind * random.uniform(-5, 5)
        discomfort_effect = discomfort * random.uniform(-5, 5)
    else:
        wind_effect = wind * random.uniform(-0.5, 0.5)
        discomfort_effect = discomfort * random.uniform(-0.5, 0.5)
    
    x += wind_effect + discomfort_effect
    y += wind_effect + discomfort_effect
    return x, y

def simulate_uniform_shots():
    global simulation_results
    simulation_results = []
    for _ in range(100):
        x_offset = random.uniform(-200, 200)
        y_offset = random.uniform(-200, 200)
        simulation_results.append((
            int(target_rect.centerx + x_offset),
            int(target_rect.centery + y_offset)
        ))

def simulate_normal_shots():
    global simulation_results
    simulation_results = []
    for _ in range(100):
        x_offset = random.gauss(0, 50)
        y_offset = random.gauss(0, 50)
        simulation_results.append((
            int(target_rect.centerx + x_offset),
            int(target_rect.centery + y_offset)
        ))

def draw_stats():
    pygame.draw.rect(screen, white, stats_rect)
    pygame.draw.rect(screen, black, stats_rect, 2)
    
    stats_data = load_stats_from_db()
    
    draw_text("Statistiky poslednych 10 hier", stats_rect.centerx, stats_rect.y + 25, blue, small_font)
    

    headers = ["Meno", "Datum", "Vietor", "Nepohoda", "Priemer", "Najlepsi"]
    for i, header in enumerate(headers):
        x = stats_rect.x + 50 + i * 75
        draw_text(header, x, stats_rect.y + 50, black, stats_font)
    
    for row_idx, stat in enumerate(stats_data):
        y = stats_rect.y + 80 + row_idx * 22
        values = [
            stat['player_name'],
            stat['session_date'].strftime("%d.%m.%Y"),
            str(stat['wind_level']),
            str(stat['discomfort_level']),
            f"{stat['average_score']:.1f}",
            str(int(stat['best_score']))
        ]
        
        for i, value in enumerate(values):
            x = stats_rect.x + 50 + i * 75
            draw_text(value, x, y, black, stats_font)
    
    if stats_data:
        avg_all = sum(s['average_score'] for s in stats_data) / len(stats_data)
        best_all = max(s['best_score'] for s in stats_data)
        
        draw_text(f"Celkovy priemer: {avg_all:.1f}", stats_rect.centerx, stats_rect.y + 320, blue, small_font)
        draw_text(f"Celkovy najlepsi: {best_all:.0f}", stats_rect.centerx, stats_rect.y + 350, blue, small_font)
    
    close_button_rect = pygame.Rect(stats_rect.right - 40, stats_rect.y + 10, 30, 30)
    pygame.draw.rect(screen, red, close_button_rect)
    draw_text("X", close_button_rect.centerx, close_button_rect.centery, white, small_font)
    
    return close_button_rect

running = True
dragging_wind = False
dragging_discomfort = False
framerate = 30
pygame.mouse.set_visible(True)
close_stats_button = None

while running:
    start_time = time.time()
    
    screen.fill(background_color)
    screen.blit(target_image, target_rect)
    pygame.draw.rect(screen, black, target_rect, 2)
    
    current_time = time.time()
    if current_time - cursor_timer > cursor_blink_interval:
        cursor_visible = not cursor_visible
        cursor_timer = current_time
    
    pygame.draw.rect(screen, white, name_input_rect)
    pygame.draw.rect(screen, black, name_input_rect, 2)
    
    text_to_display = user_name
    if active_input and cursor_visible and not game_active:
        text_to_display += "|"
    
    if not user_name and not active_input:
        draw_text("Zadajte meno", name_input_rect.centerx, name_input_rect.centery, gray)
    else:
        text_surface = font.render(text_to_display, True, black)
        if text_surface.get_width() > name_input_rect.width - 10:
            screen.blit(text_surface, (
                name_input_rect.x + 5 - (text_surface.get_width() - (name_input_rect.width - 10)), 
                name_input_rect.centery - text_surface.get_height()//2
            ))
        else:
            screen.blit(text_surface, (
                name_input_rect.x + 5, 
                name_input_rect.centery - text_surface.get_height()//2
            ))
    
    pygame.draw.rect(screen, red, delete_name_rect)
    draw_text("X", delete_name_rect.centerx, delete_name_rect.centery, white)
    
    mouse_pos = pygame.mouse.get_pos()
    if target_rect.collidepoint(mouse_pos) and game_active:
        crosshair_rect.center = mouse_pos
        crosshair_rect.center = apply_wind_and_discomfort(*crosshair_rect.center)
        screen.blit(crosshair_image, crosshair_rect)
    
    for shot in manual_shots:
        pygame.draw.circle(screen, red, shot, 5)
    
    for shot in simulation_results:
        pygame.draw.circle(screen, red, shot, 5)
    
    pygame.draw.rect(screen, white, menu_rect)
    pygame.draw.rect(screen, black, menu_rect, 2)
    
    draw_slider(wind_slider_rect, wind, 10)
    draw_text(f"Vietor: {wind} - {get_wind_description(wind)}", width // 2, height - 330)
    
    draw_slider(discomfort_slider_rect, discomfort, 10)
    draw_text(f"Nepohoda: {discomfort} - {get_discomfort_description(discomfort)}", width // 2, height - 270)
    
    pygame.draw.rect(screen, white, input_rect)
    pygame.draw.rect(screen, black, input_rect, 2)
    draw_text(str(max_shots), input_rect.centerx, input_rect.centery)
    
    arrow_color = gray if game_active else black
    pygame.draw.polygon(screen, arrow_color, [
        (up_arrow_rect.centerx, up_arrow_rect.top),
        (up_arrow_rect.left, up_arrow_rect.bottom),
        (up_arrow_rect.right, up_arrow_rect.bottom)
    ])
    pygame.draw.polygon(screen, arrow_color, [
        (down_arrow_rect.centerx, down_arrow_rect.bottom),
        (down_arrow_rect.left, down_arrow_rect.top),
        (down_arrow_rect.right, down_arrow_rect.top)
    ])
    
    button_color = red if not game_active else (150, 0, 0)
    pygame.draw.rect(screen, button_color, button_rect)
    draw_text("Start" if not game_active else "Nulovanie", button_rect.centerx, button_rect.centery, white)
    
    test_color = gray if game_active else (200, 200, 200)
    pygame.draw.rect(screen, test_color, test_uniform_button_rect)
    draw_text("Test Rovnomerny", test_uniform_button_rect.centerx, test_uniform_button_rect.centery, 
              gray if game_active else black)
    
    pygame.draw.rect(screen, test_color, test_normal_button_rect)
    draw_text("Test Normalne", test_normal_button_rect.centerx, test_normal_button_rect.centery, 
              gray if game_active else black)
    
    pygame.draw.rect(screen, green, stats_button_rect)
    draw_text("Statistiky", stats_button_rect.centerx, stats_button_rect.centery, white)
    
    if game_active and manual_shots:
        stats = calculate_stats(manual_shots)
        if stats:
            stats_y = stats_button_rect.bottom + 20
            draw_text(f"Priemerné body: {stats['average']:.1f}", stats_button_rect.centerx, stats_y, blue, small_font)
            draw_text(f"Najlepší bodový zásah: {stats['best']:.0f}", stats_button_rect.centerx, stats_y + 30, blue, small_font)
            if stats['points']:
                draw_text(f"Posledný vystrel: {stats['points'][-1]:.1f} bodov", 
                         stats_button_rect.centerx, stats_y + 60, blue, small_font)
    
    if message and time.time() - message_time < 2:
        pygame.draw.rect(screen, white, message_rect)
        pygame.draw.rect(screen, black, message_rect, 2)
        draw_text(message, message_rect.centerx, message_rect.centery, red, small_font)
    
    if show_stats:
        close_stats_button = draw_stats()
    
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            if user_name and manual_shots and game_active:
                if save_results_to_db(user_name, wind, discomfort, manual_shots):
                    message = "Vysledky uspesne ulozene do databazy!"
                else:
                    message = "Chyba pri ukladani do databazy!"
                message_time = time.time()
                pygame.display.flip()
                time.sleep(1)
            running = False
        
        elif event.type == pygame.MOUSEBUTTONDOWN:
            if name_input_rect.collidepoint(event.pos) and not game_active:
                active_input = True
                cursor_visible = True
                cursor_timer = time.time()
            else:
                active_input = False
            
            if delete_name_rect.collidepoint(event.pos) and not game_active:
                user_name = ""
            
            elif wind_slider_rect.collidepoint(event.pos) and not game_active:
                dragging_wind = True
            
            elif discomfort_slider_rect.collidepoint(event.pos) and not game_active:
                dragging_discomfort = True
            
            elif button_rect.collidepoint(event.pos):
                if not game_active:
                    if start_game():
                        message = "Hra zacata! Simulovane vystrely vymazane"
                        message_time = time.time()
                    else:
                        message = "Najprv zadajte meno!"
                        message_time = time.time()
                else:
                    reset_game()
            
            elif up_arrow_rect.collidepoint(event.pos) and not game_active:
                max_shots += 1
            elif down_arrow_rect.collidepoint(event.pos) and not game_active:
                max_shots = max(1, max_shots - 1)
            
            elif test_uniform_button_rect.collidepoint(event.pos) and not game_active:
                simulate_uniform_shots()
                message = "Simulacia 100 zasahov (rovnomerny)"
                message_time = time.time()
            
            elif test_normal_button_rect.collidepoint(event.pos) and not game_active:
                simulate_normal_shots()
                message = "Simulacia 100 zasahov (normalne)"
                message_time = time.time()
            
            elif stats_button_rect.collidepoint(event.pos):
                show_stats = True
            
            elif show_stats and close_stats_button and close_stats_button.collidepoint(event.pos):
                show_stats = False
            
            elif target_rect.collidepoint(event.pos) and game_active and not show_stats:
                current_time = time.time()
                if shots >= max_shots:
                    message = "Nimate naboje! Stlacte Nulovanie"
                    message_time = time.time()
                elif current_time - last_shot_time < shoot_cooldown:
                    remaining = shoot_cooldown - (current_time - last_shot_time)
                    message = f"Pockajte este {remaining:.1f} sekundy"
                    message_time = time.time()
                else:
                    x, y = event.pos
                    shot_x, shot_y = apply_wind_and_discomfort(x, y, is_shot=True)
                    manual_shots.append((int(shot_x), int(shot_y)))
                    distance = math.sqrt((shot_x - target_rect.centerx)**2 + (shot_y - target_rect.centery)**2)
                    points = calculate_points(distance)
                    
                    if save_results_to_db(user_name, wind, discomfort, manual_shots[-1:], is_new_session=(shots == 0)):
                        print("Vystrel ulozeny do databazy")
                    
                    message = f"Vystrel uspesny! Body: {points:.1f} (Vzdialenost: {int(distance)}px)"
                    message_time = time.time()
                    shots += 1
                    last_shot_time = current_time
        
        elif event.type == pygame.MOUSEBUTTONUP:
            dragging_wind = False
            dragging_discomfort = False
        
        elif event.type == pygame.KEYDOWN:
            if active_input and not game_active:
                if event.key == pygame.K_RETURN:
                    active_input = False
                elif event.key == pygame.K_BACKSPACE:
                    user_name = user_name[:-1]
                    cursor_timer = time.time()
                elif event.unicode.isprintable() and len(user_name) < 20:
                    user_name += event.unicode
                    cursor_timer = time.time()
            elif event.key == pygame.K_ESCAPE and show_stats:
                show_stats = False
        
        elif event.type == pygame.MOUSEMOTION:
            last_move_time = time.time()
            if dragging_wind and not game_active:
                rel_x = event.pos[0] - wind_slider_rect.x
                wind = max(0, min(10, int(rel_x / wind_slider_rect.width * 10)))
            elif dragging_discomfort and not game_active:
                rel_x = event.pos[0] - discomfort_slider_rect.x
                discomfort = max(0, min(10, int(rel_x / discomfort_slider_rect.width * 10)))
    
    pygame.display.flip()
    
    frame_time = time.time() - start_time
    delay = max(0, 1.0 / framerate - frame_time)
    time.sleep(delay)

pygame.quit()
sys.exit()
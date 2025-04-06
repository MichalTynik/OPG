using System;
using System.Runtime.InteropServices;
using Gdk;
using Gtk;
using Key = Gtk.Key;
using Window = Gtk.Window;
using System.Threading.Tasks;
using System.Runtime.Intrinsics.X86;
using System.Collections.Generic;
using Terc;
using MySqlConnector;

public class TercWindow : Gtk.Window
{
    readonly string _executableDirectory = AppDomain.CurrentDomain.BaseDirectory;

    private readonly Fixed _fixedCross;
    private readonly Image _crosshairImage;
    private readonly string[] _windDir = new[] { "Sever", "Juh", "Zapad", "Vychod" };
    private Window _window;
    private List<Image> _shotStorage = new List<Image>();

    private Entry _inputField = new Entry();
    private Entry _nameEntry = new Entry(); // New Entry for player name
    private Button _windButton = new Button();
    private bool _startToggle = false;
    private int _totalScore = 0;
    private int _attempts = 0;
    private int _bestScore = 0;
    private Label _scoreLabel;
    private Scale _weatherScale;
    private Scale _fatigueScale;
    private int _crosshairX = 360; 
    private int _crosshairY = 360; 
    private Task _movementTask; 
    private int _shotsNumber;
    private string _dir = "Sever";
    private DatabaseConnector _databaseConnector;

    public TercWindow() : base("TercWindow")
    {
        _window = this;
        SetDefaultSize(800, 900);
        Destroyed += (sender, e) => Application.Quit();
        BorderWidth = 10;

        _fixedCross = new Fixed();
        _fixedCross.SetSizeRequest(800, 900);
        Add(_fixedCross);

        _fixedCross.Put(CreateVBox(), 0, 0);
        _crosshairImage = CreateCrossHair();
        _fixedCross.Put(_crosshairImage, _crosshairX, _crosshairY);

        _inputField.Changed += EntryOutput;
        KeyPressEvent += ShotKeyListener;
        _windButton.Pressed += WindChanged;
        _databaseConnector = new DatabaseConnector("3306", "127.0.0.1", "Programator", "Kira.2022", "Terc");
        ShowAll();
    }

    /// <summary>
    /// Vytvori celkove UI
    /// </summary>
    /// <returns></returns>
    private VBox CreateVBox()
    {
        _weatherScale = new Scale(Orientation.Horizontal, 1, 10, 1);
        _fatigueScale = new Scale(Orientation.Horizontal, 1, 10, 1);
        Button start = new Button("Start");
        Label fatigueLabel = new Label("Unava");
        Label weatherLabel = new Label("Vietor");
        _windButton = new Button("Sever");
        _scoreLabel = new Label($"Skore: {_totalScore}");
        Button showScoresButton = new Button("Tabulka");
        showScoresButton.Clicked += OnShowScoresButtonClicked;
        Label nameLabel = new Label("Meno:"); 

        start.Pressed += StartOrNull;

        Grid grid = new Grid();
        grid.ColumnSpacing = 50;
        grid.RowSpacing = 10;

        grid.Attach(_weatherScale, 0, 1, 9, 1);
        grid.Attach(_fatigueScale, 0, 3, 9, 1);
        grid.Attach(_inputField, 8, 1, 6, 2);
        grid.Attach(fatigueLabel, 0, 2, 1, 1);
        grid.Attach(weatherLabel, 0, 0, 1, 1);
        grid.Attach(_windButton, 8, 2, 6, 2);
        grid.Attach(start, 0, 4, 9, 1);
        grid.Attach(_scoreLabel, 9, 5, 1, 1);
        grid.Attach(showScoresButton, 0, 6, 9, 1);
        grid.Attach(nameLabel, 0, 5, 1, 1);     
        grid.Attach(_nameEntry, 1, 5, 8, 1);   

        VBox vbox = new VBox(false, 0);
        vbox.PackStart(CreateTarget(), true, true, 0);
        vbox.PackStart(grid, false, false, 0);
        return vbox;
    }

    /// <summary>
    /// Po stlaceni tlacidla "Tabulka" sa zavola trieda navytvorenie noveho okna
    /// </summary>
    /// <seealso cref="ShowScoresWindow"/>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnShowScoresButtonClicked(object sender, EventArgs e)
    {
        ShowScoresWindow scoresWindow = new ShowScoresWindow(_databaseConnector);
        scoresWindow.ShowAll();
    }

    /// <summary>
    /// Ziskava pocet vystrelov z Entry(_inputField)
    /// </summary>
    /// <param name="o"></param>
    /// <param name="args"></param>
    private void EntryOutput(object o, EventArgs args)
    {
        int.TryParse(_inputField.Text, out _shotsNumber);
        Console.WriteLine($"Shots: {_shotsNumber}");
    }

    /// <summary>
    /// Pohyb zamerovaca podla pohybu mysky
    /// </summary>
    private async Task MoveCrosshair()
    {
        Random random = new Random();
        int originalMouseX = 0;
        int originalMouseY = 0;
        int targetX = _crosshairX;
        int targetY = _crosshairY;
        DateTime lastTargetUpdate = DateTime.Now;
        Display.Default.GetPointer(out originalMouseX, out originalMouseY, out ModifierType mask);

        while (_startToggle)
        {
            if ((DateTime.Now - lastTargetUpdate).TotalMilliseconds >= 100)
            {
                int fatigueIntensity = (int)_fatigueScale.Value;
                double fatigueFactor = fatigueIntensity * 20;
                int offsetX = (int)(random.NextDouble() * 2 * (fatigueFactor) - (fatigueFactor));
                int offsetY = (int)(random.NextDouble() * 2 * (fatigueFactor) - (fatigueFactor));
                targetX = originalMouseX + offsetX - 40;
                targetY = originalMouseY + offsetY - 40;
                targetX = Math.Max(0, Math.Min(targetX, 800 - _crosshairImage.Allocation.Width + 100));
                targetY = Math.Max(0, Math.Min(targetY, 900 - _crosshairImage.Allocation.Height - 80));
                lastTargetUpdate = DateTime.Now;
            }

            _crosshairX = (int)(_crosshairX * 0.98 + targetX * 0.02);
            _crosshairY = (int)(_crosshairY * 0.98 + targetY * 0.02);

            Application.Invoke(delegate {
                _fixedCross.Move(_crosshairImage, _crosshairX , _crosshairY);
            });

            await Task.Delay(8);
            Display.Default.GetPointer(out originalMouseX, out originalMouseY, out mask);
        }
    }

    /// <summary>
    /// Ziska a vrati poziciu zameriavaca
    /// </summary>
    /// <returns>X a Y poziciu zameriavaca</returns>
    (int x, int y) GetCrosshairPosition()
    {
        _crosshairImage.TranslateCoordinates(_window, 0, 0, out int x, out int y);
        return (x, y);
    }

    /// <summary>
    /// Po stlaceni tlacidla "Start" spusti simulaciu
    /// </summary>
    /// <param name="o"></param>
    /// <param name="args"></param>
    public void StartOrNull(object? o, EventArgs args)
    {
        _startToggle = !_startToggle;
        if (_startToggle)
        {
            _attempts++;
            if (_inputField.Text.Length > 0)
            {
                for (int i = 0; i < _shotsNumber; i++)
                {
                    Shot();
                    CalculateScore();
                }
            }
            else
            {
                Task.Run(() => MoveCrosshair());
            }
        }
        else
        {
            _movementTask?.Wait();
            _movementTask = null;
            _crosshairX = 360;
            _crosshairY = 360;
            Application.Invoke(delegate { _fixedCross.Move(_crosshairImage, _crosshairX, _crosshairY); });
            UpdateScoreInDatabase();
            ResetTarget();
        }
    }

    /// <summary>
    /// Po slaceni tlacidla s nazvom svetovej strany, zmeni nazov a smer vetra
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private void WindChanged(object sender, EventArgs args)
    {
        Random rnd = new Random();
        
        
        if (_windButton.Child is Gtk.Label label)
        {
            do
            {
            _dir = _windDir[rnd.Next(_windDir.Length)];
            } while (_dir == label.Text);
            label.Text = _dir;
        }
    }

    /// <summary>
    /// Aktualizuje databazu
    /// </summary>
    /// <seealso cref="DatabaseConnector"/>
    private void UpdateScoreInDatabase()
    {
        string playerName = _nameEntry.Text.Trim(); 
        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Training"; 
        }
        string updateQuery = $"INSERT INTO Players (Meno, NajSkore, CelkoveSkore, Pokusy) " +
                             $"VALUES ('{playerName}', {_bestScore}, {_totalScore}, {_attempts}) " +
                             $"ON DUPLICATE KEY UPDATE NajSkore = GREATEST(NajSkore, {_bestScore}), " +
                             $"CelkoveSkore = CelkoveSkore + {_totalScore}, " +
                             $"Pokusy = Pokusy + {_attempts};";
        _databaseConnector.ExecuteQuery(updateQuery);
        _bestScore = 0;
        _totalScore = 0;
        _attempts = 0;
    }

    /// <summary>
    /// Vymaze vsetky streli
    /// </summary>
    private void ResetTarget()
    {
        foreach (var img in _shotStorage)
        {
            img.Hide();
        }
        _totalScore = 0;
        _scoreLabel.Text = $"Score: {_totalScore}";
    }

    /// <summary>
    /// Po stlaceni klavesi "S" vystreli a vypocita skore
    /// </summary>
    /// <param name="o"></param>
    /// <param name="args"></param>
    private void ShotKeyListener(object? o, KeyPressEventArgs args)
    {
        if (args.Event.Key == Gdk.Key.s)
        {
            Console.WriteLine("Shot!");
            Shot();
            CalculateScore();
        }
    }

    /// <summary>
    /// Vypocita trajektoriu a vytvori strelu na terci 
    /// </summary>
    private void Shot()
    {
        try
        {
            Pixbuf pix = new Pixbuf(System.IO.Path.Combine(_executableDirectory, "bullet.png"));
            Pixbuf pixScaled = pix.ScaleSimple(50, 50, InterpType.Bilinear);
            Image image = new Image(pixScaled);
            _shotStorage.Add(image);
            Random shotRandom = new Random();
            int windIntensity = (int)_weatherScale.Value * 20;

            _fixedCross.Put(image, ChangeShotDirection(windIntensity, shotRandom).x - 20, ChangeShotDirection(windIntensity, shotRandom).y - 55);
            image.Show();

            _fixedCross.Remove(_crosshairImage);
            _fixedCross.Put(_crosshairImage, _crosshairX, _crosshairY);
            _crosshairImage.Show();
        }
        catch (GLib.GException e)
        {
            Console.WriteLine("Failed to load shot image " + e);
            throw;
        }
    }

    /// <summary>
    /// Zmeni trajektoriu podla smeru vetra
    /// </summary>
    /// <see cref="_dir"/>
    /// <param name="windIntensity">Sila vetra</param>
    /// <param name="shotRandom"></param>
    /// <returns>X a Y poziciu strely</returns>
    (int x, int y) ChangeShotDirection(int windIntensity, Random shotRandom)
    {
        int x, y;
        switch (_dir)
        {
            case "Sever":
                x = GetCrosshairPosition().x + shotRandom.Next(-windIntensity / 2, windIntensity / 2);
                y= GetCrosshairPosition().y + shotRandom.Next(0, windIntensity / 2);
                break;
            case "Juh":
                x = GetCrosshairPosition().x + shotRandom.Next(-windIntensity / 2, windIntensity / 2);
                y= GetCrosshairPosition().y + shotRandom.Next(-windIntensity / 2, 0);
                break;
            case "Zapad":
                x = GetCrosshairPosition().x + shotRandom.Next(0, windIntensity / 2);
                y = GetCrosshairPosition().y + shotRandom.Next(-windIntensity / 2, windIntensity / 2);
                break;
            case "Vychod":
                x = GetCrosshairPosition().x + shotRandom.Next(-windIntensity / 2, 0);
                y = GetCrosshairPosition().y + shotRandom.Next(-windIntensity / 2, windIntensity / 2);
                break;
            default:
                x = GetCrosshairPosition().x + shotRandom.Next(-windIntensity / 2, windIntensity / 2);
                y = GetCrosshairPosition().y + shotRandom.Next(-windIntensity / 2, windIntensity / 2);
                break;
        }
        return (x, y);
    }


    /// <summary>
    /// Vypocita skore
    /// </summary>
    private void CalculateScore()
    {
        int shotX = GetCrosshairPosition().x;
        int shotY = GetCrosshairPosition().y;
        int centerX = 440;
        int centerY = 440;

        double distance = Math.Sqrt(Math.Pow(shotX - centerX, 2) + Math.Pow(shotY - centerY, 2));
        int currentScore = 0;

        if (distance <= 80)
            currentScore = 5;
        else if (distance <= 150)
            currentScore = 4;
        else if (distance <= 230)
            currentScore = 3;
        else if (distance <= 310)
            currentScore = 2;
        else if (distance <= 390)
            currentScore = 1;

        
        _totalScore += currentScore;
        _bestScore = Math.Max(_bestScore, _totalScore);
        _scoreLabel.Text = $"Score: {_totalScore}";
    }

    /// <summary>
    /// Vytvori a nastavi obrazok terca
    /// </summary>
    /// <returns>Image target</returns>
    private Image CreateTarget()
    {
        try
        {
            Pixbuf pxbf = new Pixbuf(System.IO.Path.Combine(_executableDirectory, "terc.jpg"));
            Pixbuf rescaledPixbuf = pxbf.ScaleSimple(800, 800, InterpType.Bilinear);
            return new Image { Pixbuf = rescaledPixbuf };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading target image: {ex.Message}");
            return new Image();
        }
    }

    /// <summary>
    /// Vytvori a nastavi obrazok zameriavaca
    /// </summary>
    /// <returns>Image crosshair</returns>
    private Image CreateCrossHair()
    {
        try
        {
            Pixbuf pxbf = new Pixbuf(System.IO.Path.Combine(_executableDirectory, "crosshair.png"));
            Pixbuf rescaledPixbuf = pxbf.ScaleSimple(80, 80, InterpType.Bilinear);
            return new Image { Pixbuf = rescaledPixbuf };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading crosshair image: {ex.Message}");
            return new Image();
        }
    }

    public static void Main(string[] args)
    {
        Application.Init();
        new TercWindow();
        Application.Run();
    }
}
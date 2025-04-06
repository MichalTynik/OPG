using System;
using System.Runtime.InteropServices;
using Gdk;
using Gtk;
using Key = Gtk.Key;
using Window = Gtk.Window;
using System.Threading.Tasks;
using System.Runtime.Intrinsics.X86;
using System.Collections.Generic;

public class TercWindow : Gtk.Window
{
    readonly string _executableDirectory = AppDomain.CurrentDomain.BaseDirectory;
    
    private readonly Fixed _fixedCross;
    private readonly Image _crosshairImage;
    private Window _window;
    private List<Image> _shotStorage = new List<Image>();
    
    Entry _inputField = new Entry();
    private bool _startToggle = false;
    private int _totalScore = 0;
    private Label _scoreLabel;
    private Scale _weatherScale;
    private Scale _fatigueScale;
    private int _crosshairX = 360; // Aktuálna X pozícia krížika
    private int _crosshairY = 360; // Aktuálna Y pozícia krížika
    private Task _movementTask; // Úloha pre kontinuálny pohyb
    private int _shotsNumber;

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
        ShowAll();
    }

    private VBox CreateVBox()
    {
        _weatherScale = new Scale(Orientation.Horizontal, 1, 10, 1);
        _fatigueScale = new Scale(Orientation.Horizontal, 1, 10, 1);
        Button start = new Button("Start");
        Label fatigueLabel = new Label("Fatigue");
        Label weatherLabel = new Label("Weather");
        Label windLabel = new Label("Sever");
        _scoreLabel = new Label($"Score: {_totalScore}");

        start.Pressed += StartOrNull;

        Grid grid = new Grid();
        grid.ColumnSpacing = 50;
        grid.RowSpacing = 10;

        grid.Attach(_weatherScale, 0, 1, 3, 1);
        grid.Attach(_fatigueScale, 0, 3, 3, 1);
        grid.Attach(_inputField, 3, 1, 1, 1);
        grid.Attach(fatigueLabel, 0, 2, 1, 1);
        grid.Attach(weatherLabel, 0, 0, 1, 1);
        grid.Attach(windLabel, 3, 2, 1, 1);
        grid.Attach(start, 5, 1, 1, 1);
        grid.Attach(_scoreLabel, 5, 2, 1, 1);

        VBox vbox = new VBox(false, 0);
        vbox.PackStart(CreateTarget(), true, true, 0);
        vbox.PackStart(grid, false, false, 0);
        return vbox;
    }

    private void EntryOutput(object o, EventArgs args)
    {
        int.TryParse(_inputField.Text, out _shotsNumber);
        Console.WriteLine($"Shots: {_shotsNumber}");
    }

    private async Task MoveCrosshair()
    {
        Random random = new Random();
        int originalMouseX = 0; // Pôvodná X pozícia myši
        int originalMouseY = 0; // Pôvodná Y pozícia myši
        int targetX = _crosshairX;
        int targetY = _crosshairY;

        // Pre správu času poslednej aktualizácie cieľovej pozície
        DateTime lastTargetUpdate = DateTime.Now;

        // Získaj počiatočnú polohu myši
        Display.Default.GetPointer(out originalMouseX, out originalMouseY, out ModifierType mask);

        while (_startToggle)
        {
            // Aktualizuj cieľovú pozíciu každých 100 ms
            if ((DateTime.Now - lastTargetUpdate).TotalMilliseconds >= 100)
            {
                int fatigueIntensity = (int)_fatigueScale.Value;

                double fatigueFactor = fatigueIntensity * 20;

                int offsetX = (int)(random.NextDouble() * 2 * (fatigueFactor) - (fatigueFactor));
                int offsetY = (int)(random.NextDouble() * 2 * ( fatigueFactor) - ( fatigueFactor));

                // Vypočítaj cieľovú pozíciu na základe aktuálnej pozície myši
                targetX = originalMouseX + offsetX - 40;
                targetY = originalMouseY + offsetY - 40;

                targetX = Math.Max(0, Math.Min(targetX, 800 - _crosshairImage.Allocation.Width + 100));
                targetY = Math.Max(0, Math.Min(targetY, 900 - _crosshairImage.Allocation.Height - 80));

                lastTargetUpdate = DateTime.Now;
            }

            // Plynulá interpolácia smerom k cieľovej pozícii (aktuálna pozícia sa spomalene približuje k cieľu)
            _crosshairX = (int)(_crosshairX * 0.98 + targetX * 0.02);
            _crosshairY = (int)(_crosshairY * 0.98 + targetY * 0.02);

            // Aktualizuj pozíciu krížika v UI
            Application.Invoke(delegate {
                _fixedCross.Move(_crosshairImage, _crosshairX , _crosshairY);
            });

            await Task.Delay(8);

            // Aktualizuj aktuálnu polohu myši pre prípad zmeny
            Display.Default.GetPointer(out originalMouseX, out originalMouseY, out mask);
        }
    }

    (int x, int y) GetCrosshairPosition()
    {
        _crosshairImage.TranslateCoordinates(_window, 0, 0, out int x, out int y);
        return (x, y);
    }

    public void StartOrNull(object? o, EventArgs args)
    {
        _startToggle = !_startToggle;
        if (_startToggle)
        {
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
            ResetTarget();
        }
    }
    private async Task ShootMultipleTimes(int shotCount)
    {
        Random shotRandom = new Random();
        int middleX = 440;
        int middleY = 440;
        int wind = (int)_weatherScale.Value;
        int fatigue = (int)_fatigueScale.Value;
        for (int i = 0; i < shotCount; i++)
        {
            Shot();
        }
    }

    private void ResetTarget()
    {
        foreach (var img in _shotStorage)
        {
            img.Hide();
        }
        _totalScore = 0;
        _scoreLabel.Text = $"Score: {_totalScore}";
    }

    private void ShotKeyListener(object? o, KeyPressEventArgs args)
    {
        if (args.Event.Key == Gdk.Key.s)
        {
            Console.WriteLine("Shot!");
            Shot();
            CalculateScore();
        }
    }

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
            int shotX = GetCrosshairPosition().x + shotRandom.Next(-windIntensity / 2, windIntensity / 2);
            int shotY = GetCrosshairPosition().y + shotRandom.Next(-windIntensity / 2, windIntensity / 2);

            _fixedCross.Put(image, shotX - 20, shotY - 55);
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
    

    private void CalculateScore()
    {
        int shotX = GetCrosshairPosition().x;
        int shotY = GetCrosshairPosition().y;
        int centerX = 440;
        int centerY = 440;

        double distance = Math.Sqrt(Math.Pow(shotX - centerX, 2) + Math.Pow(shotY - centerY, 2));

        if (distance <= 80)
            _totalScore += 5;
        else if (distance <= 150)
            _totalScore += 4;
        else if (distance <= 230)
            _totalScore += 3;
        else if (distance <= 310)
            _totalScore += 2;
        else if (distance <= 390)
            _totalScore += 1;

        _scoreLabel.Text = $"Score: {_totalScore}";
    }

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

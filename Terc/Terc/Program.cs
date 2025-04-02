using System;
using System.Runtime.InteropServices;
using Gdk;
using Gtk;
using Key = Gtk.Key;
using Window = Gtk.Window;

public class TercWindow : Gtk.Window
{
    static CancellationTokenSource ctsSource = new CancellationTokenSource();
    CancellationToken cts = ctsSource.Token;
    private readonly Fixed _fixedCross;
    private readonly Image _crosshairImage;
    private Window _window;
    private List<Image> _shotStorage = new List<Image>();

    private bool _startToggle;
    private int _totalScore = 0; // Add score variable
    private Label _scoreLabel; // Add score label


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
        _fixedCross.Put(_crosshairImage, 360, 360);

        KeyPressEvent += ShotKeyListener;

        ShowAll();
    }


    private VBox CreateVBox()
    {
        Scale weather = new Scale(Orientation.Horizontal, 0, 10, 1);
        Scale fatigue = new Scale(Orientation.Horizontal, 0, 10, 1);
        Button start = new Button("Start");
        Entry inputField = new Entry();
        Label fatiqueLabel = new Label("Fatigue");
        Label weatherLabel = new Label("Weather");
        Label windLabel = new Label("Sever");
        _scoreLabel = new Label($"Score: {_totalScore}"); // Initialize score label

        start.Pressed += StartOrNull;

        Grid grid = new Grid();
        grid.ColumnSpacing = 50;
        grid.RowSpacing = 10;

        grid.Attach(weather, 0, 1, 3, 1);
        grid.Attach(fatigue, 0, 3, 3, 1);
        grid.Attach(inputField, 3, 1, 1, 1);
        grid.Attach(fatiqueLabel, 0, 2, 1, 1);
        grid.Attach(weatherLabel, 0, 0, 1, 1);
        grid.Attach(windLabel, 3, 2, 1, 1);
        grid.Attach(start, 5, 1, 1, 1);
        grid.Attach(_scoreLabel, 5, 2, 1, 1); // Attach score label to grid

        VBox vbox = new VBox(false, 0);
        vbox.PackStart(CreateTarget(), true, true, 0);
        vbox.PackStart(grid, false, false, 0);
        return vbox;
    }

    private Image CreateTarget()
    {
        try
        {
            Pixbuf pxbf = new Pixbuf("/home/michaltynik/Dokumenty/SPSE/OPG/Terc/Terc/terc.jpg");
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
            Pixbuf pxbf = new Pixbuf("/home/michaltynik/Dokumenty/SPSE/OPG/Terc/Terc/crosshair.png");
            Pixbuf rescaledPixbuf = pxbf.ScaleSimple(80, 80, InterpType.Bilinear);
            return new Image { Pixbuf = rescaledPixbuf };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading crosshair image: {ex.Message}");
            return new Image(); // Return an empty image on error.
        }
    }

    public void OnMouseMotionEvent(object o, MotionNotifyEventArgs args)
    {
        if (args.Event.Device != null && args.Event.Window != null)
        {
            int x, y;
            ModifierType mask;
            args.Event.Window.GetDevicePosition(args.Event.Device, out x, out y, out mask);
            Console.WriteLine("x: " + x + " y:" + y);
            x = Math.Max(0, Math.Min(x, 800 - _crosshairImage.Allocation.Width + 100));
            y = Math.Max(0, Math.Min(y, 900 - _crosshairImage.Allocation.Height - 80));
            _fixedCross.Move(_crosshairImage, x - 80, y - 80);

        }
    }

    public void StartOrNull(object? o, EventArgs args)
    {
        if (!_startToggle)
        {

            //Task myTask = RealisticSims();
            MotionNotifyEvent += OnMouseMotionEvent;
            Events |= EventMask.PointerMotionMask;
        }
        else
        {
            ctsSource.Cancel();
            MotionNotifyEvent -= OnMouseMotionEvent;
            _fixedCross.Move(_crosshairImage, 360, 360);
            ResetTarget();
        }

        _startToggle = !_startToggle;
    }

    private void ResetTarget()
    {
        foreach (var var in _shotStorage)
        {
            var.Hide();
        }
        _totalScore = 0;
        _scoreLabel.Text = $"Score: {_totalScore}";
    }

    private void ShotKeyListener(object? o, KeyPressEventArgs args)
    {
        if (args.Event.Key == Gdk.Key.s)
        {
            Console.WriteLine("Shot!");
            UpdateImage();
            CalculateScore();
        }
    }

    private void UpdateImage()
    {
        try
        {
            Pixbuf pix = new Pixbuf("/home/michaltynik/Dokumenty/SPSE/OPG/Terc/Terc/bullet.png");
            Pixbuf pixScaled = pix.ScaleSimple(50, 50, InterpType.Bilinear);
            Image image = new Image(pixScaled);
            _shotStorage.Add(image);
            _fixedCross.Put(image, GetCrosshairPosition().x - 20, GetCrosshairPosition().y - 55);
            image.Show();
        }
        catch (GLib.GException e)
        {
            Console.WriteLine("Failed to load shot image " + e);
            throw;
        }

    }

    private async Task RealisticSims()
    {
        int x, y;
        ModifierType mask;
        while (true)
        {
            if (cts.IsCancellationRequested)
                cts.ThrowIfCancellationRequested();
            x = GetCrosshairPosition().x;
            y = GetCrosshairPosition().y;
            x = Math.Max(0, Math.Min(x, 800 - _crosshairImage.Allocation.Width));
            y = Math.Max(0, Math.Min(y, 900 - _crosshairImage.Allocation.Height));
            _fixedCross.Move(_crosshairImage, x - 80, y - 80);
        }
    }

    (int x, int y) GetCrosshairPosition()
    {
        _crosshairImage.TranslateCoordinates(_window, 0, 0, out int x, out int y);
        return (x, y);
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

    public static void Main(string[] args)
    {

        Application.Init();
        new TercWindow();
        Application.Run();
    }
}
//naprogramovat bodovanie
//Funkcia ktora bude fungovat ako tranform to point kde budu 4 sekcie 1. +x -y 2. -x -y 3. -x +y 4. +x +y
//Smeri vetra (Posunie sa nulty bod)
//databaza
//S:[445,445] 5:[510,445] 4:[590,445] 3:[675,445] 2:[755,445] 1:[835,445]


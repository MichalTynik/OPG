using System;
using Gdk;
using Gtk;
using Terc;

public class TercWindow : Gtk.Window
{
    private Fixed fixedCross;
    private Image crosshairImage;
    private GameBackEnd  gameBackEnd;

    public TercWindow() : base("Terc")
    {
        SetDefaultSize(800, 900);
        Destroyed += (sender, e) => Application.Quit();
        BorderWidth = 10;
        

        fixedCross = new Fixed();
        fixedCross.SetSizeRequest(800, 900);
        Add(fixedCross);

        fixedCross.Put(CreateVBox(), 0, 0);
        crosshairImage = CreateCrossHair();
        fixedCross.Put(crosshairImage, 400, 400);

        MotionNotifyEvent += OnMouseMotionEvent;
        Events |= EventMask.PointerMotionMask;

        ShowAll();
    }

    private VBox CreateVBox()
    {
        Scale weather = new Scale(Orientation.Horizontal, 0, 10, 1);
        Scale fatigue = new Scale(Orientation.Horizontal, 0, 10, 1);
        Button start = new Button("Start");
        Entry inputField = new Entry();
        Label Fatiquelabel = new Label("Fatigue");
        Label Weatherlabel = new Label("Weather");
        Label Windlabel = new Label("Sever");

        start.Pressed += gameBackEnd.StartOrNull;
        
        Grid grid = new Grid();
        grid.ColumnSpacing = 50;
        grid.RowSpacing = 10;

        grid.Attach(weather, 0, 1, 3, 1);
        grid.Attach(fatigue, 0, 3, 3, 1);
        grid.Attach(inputField, 3, 1, 1, 1);
        grid.Attach(Fatiquelabel, 0, 2, 1, 1);
        grid.Attach(Weatherlabel, 0, 0, 1, 1);
        grid.Attach(Windlabel, 3, 2, 1, 1);
        grid.Attach(start, 5, 1, 1, 1);

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

    private void OnMouseMotionEvent(object o, MotionNotifyEventArgs args)
    {
        if (args.Event.Device != null && args.Event.Window != null)
        {
            int x, y;
            ModifierType mask;
            args.Event.Window.GetDevicePosition(args.Event.Device, out x, out y, out mask);
            x = Math.Max(0, Math.Min(x, 800 - crosshairImage.Allocation.Width));
            y = Math.Max(0, Math.Min(y, 900 - crosshairImage.Allocation.Height));
            fixedCross.Move(crosshairImage, x, y);
        }
    }

    public static void Main(string[] args)
    {
        Application.Init();
        new TercWindow();
        Application.Run();
    }
}
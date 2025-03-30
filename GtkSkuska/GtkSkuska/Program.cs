using Gtk;

Application.Init();
Window win = new Window("Skuska");
VBox vbox = new VBox();
Button btn = new Button("button");
vbox.Add(btn);
win.Add(vbox);
win.ShowAll();
Application.Run();
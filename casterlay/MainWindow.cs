using System;
using System.IO;
using casterlay;
using Gdk;
using Gtk;

public partial class MainWindow : Gtk.Window
{
	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();
		Gtk.FileFilter filter = new FileFilter();
		filter.Name = "Images";
		filter.AddMimeType("image/png");
		filter.AddMimeType("image/jpeg");
		filter.AddMimeType("image/gif");
		filter.AddPattern("*.png");
		filter.AddPattern("*.jpg");
		filter.AddPattern("*.gif");
		filter.AddPattern("*.tif");
		filter.AddPattern("*.xpm");
		filechooserwidget1.Filter = filter;
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}

	protected void OnButton2Clicked(object sender, EventArgs e)
	{
		spinbutton1.Spin(SpinType.Home, 1f);
		spinbutton2.Spin(SpinType.Home, 1f);
	}

	Pixbuf img = null;

	protected void OnFilechooserwidget1SelectionChanged(object sender, EventArgs e)
	{
		
		label5.Text = "Selected: "+filechooserwidget1.Filename;
		if (filechooserwidget1.PreviewFilename != null)
		{
			img = new Pixbuf(filechooserwidget1.Filename);
		}
	}

	protected void OnButton8Clicked(object sender, EventArgs e)
	{
		if (img != null)
		{
			new Overlay(img);
		}
	}
}

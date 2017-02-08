using System;
using Gdk;
using Gtk;

namespace casterlay
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class Overlay : Gtk.Window
	{
		Pixbuf img;
		float factor;

		public Overlay(Pixbuf img):base("Casterlay")
		{
			this.Decorated = false;
			this.KeepAbove = true;
			this.Opacity = 0f;
			Build();
			this.img = img;
			buildOverlay();
		}

		void buildOverlay()
		{
			Style style = this.Style;
			Pixmap map, mask;
			factor = Screen.Width / img.Width;
			img = img.ScaleSimple(Screen.Width, (int)(img.Height * factor), InterpType.Bilinear);
			Console.WriteLine("Width: " + img.Width + " Height: " + img.Height + " Factor: " + factor);
			img.RenderPixmapAndMask(out map, out mask, 255);
			image3.Pixbuf = img;
			SetDefaultSize(img.Width, img.Height);
			SetPosition(WindowPosition.Center);
			style.SetBgPixmap(StateType.Normal, map);
			this.Style = style;
			Show();
		}
}
}

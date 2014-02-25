using Gtk;
using System;

namespace Serpis.Ad
{
	
	public partial class CategoriaView : Gtk.Window
	{
		private System.Action saveActionDelegate;
		
		public CategoriaView () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			
			saveAction.Activated += delegate {
				saveActionDelegate();
				Destroy();
			};
		}
		
		[Model]
		public string Nombre {
			get {return entryNombre.Text;}
			set {entryNombre.Text = value;}
		}
		
		public System.Action SaveActionDelegate {
			set {saveActionDelegate = value;}
		}
	}
}


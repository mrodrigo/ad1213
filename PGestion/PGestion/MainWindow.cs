using Gtk;
using System;

using Serpis.Ad;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		UiManagerHelper uiManagerHelper = new UiManagerHelper(UIManager);

		CategoriaListView categoriaListView = new CategoriaListView();
		notebook.AppendPage (categoriaListView, new Label("Categorias"));
		
		uiManagerHelper.SetActionGroup (categoriaListView.ActionGroup);
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}

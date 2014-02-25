using Gtk;
using System;

namespace Serpis.Ad
{
	public class CategoriaListView : EntityListView
	{
		public CategoriaListView ()	{
			
			TreeViewHelper treeViewHelper = new TreeViewHelper(treeView, App.Instance.DbConnection, "select id, nombre from categoria");
			
			Gtk.Action refreshAction = new Gtk.Action("refreshAction", null, null, Stock.Refresh);
			refreshAction.Activated += delegate {
				treeViewHelper.Refresh ();
			};
			actionGroup.Add (refreshAction);
			
			Gtk.Action editAction = new Gtk.Action("editAction", null, null, Stock.Edit);
			editAction.Activated += delegate {
				Categoria categoria = Categoria.Load (treeViewHelper.Id);
				CategoriaView categoriaView = new CategoriaView();
				new CategoriaController(categoria, categoriaView);
				categoriaView.Show ();
			};
			actionGroup.Add (editAction);
			
			
		}
	}
}


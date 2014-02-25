using System;
using System.Reflection;

namespace Serpis.Ad
{
	public class CategoriaController
	{
		public CategoriaController (Categoria categoria, CategoriaView categoriaView)
		{
			//categoriaView.Nombre = categoria.Nombre;
			SetView(categoriaView, categoria);
			
			categoriaView.SaveActionDelegate = delegate {
				categoria.Nombre = categoriaView.Nombre;
				Categoria.Save(categoria);
			};
		}
		
		public static void SetView(object view, object model) {
			Type viewType = view.GetType ();
			Type modelType = model.GetType ();
			
			foreach (PropertyInfo viewPropertyInfo in viewType.GetProperties ()) 
				if (viewPropertyInfo.IsDefined(typeof(ModelAttribute), true)) {
					PropertyInfo modelPropertyInfo = modelType.GetProperty(viewPropertyInfo.Name);
					object value = modelPropertyInfo.GetValue (model, null);
					viewPropertyInfo.SetValue(view, value, null);
				}
		}
	}
	
	public class ModelAttribute : Attribute 
	{
	}
}


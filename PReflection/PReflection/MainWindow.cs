using Gtk;
using System;
using System.Reflection;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		executeAction.Activated += delegate {
			showProperties (typeof(Persona));
		};
	}
	
	private void showProperties(Type type) {
		PropertyInfo[] propertyInfos = type.GetProperties();
		foreach(PropertyInfo propertyInfo in propertyInfos)
			if (propertyInfo.IsDefined (typeof(KeyAttribute), true))
				textView.Buffer.Text = textView.Buffer.Text + propertyInfo.Name + " " + propertyInfo.PropertyType + "\n";
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}

public class Persona {
	private string nombre;
	private DateTime fechaNacimiento;
	
	[Key]
	public DateTime FechaNacimiento {
		get {return this.fechaNacimiento;}
		set {fechaNacimiento = value;}
	}
	
	[Field]
	public string Nombre {
		get {return this.nombre;}
		set {nombre = value;}
	}
}

public class FieldAttribute : Attribute
{
}

public class KeyAttribute : Attribute 
{
}
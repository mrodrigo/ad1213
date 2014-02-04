using Gtk;
using System;
using MySql.Data.MySqlClient;

namespace Serpis.Ad
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			
			Categoria categoria = (Categoria)Categoria.Load (typeof(Categoria), "");
			Console.WriteLine ("categoria.Nombre={0}", categoria.Nombre);
			
			return;
			
			App.Instance.DbConnection = new MySqlConnection("Server=localhost;Database=dbprueba;User Id=root;Password=sistemas");
			
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}

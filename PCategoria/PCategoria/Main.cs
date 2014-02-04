using MySql.Data.MySqlClient;
using System;
using System.Data;


namespace Serpis.Ad
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			App.Instance.DbConnection = new MySqlConnection("Server=localhost;Database=dbprueba;User Id=root;Password=sistemas");
			Categoria categoria = Categoria.Load ("2");
			
			categoria.Nombre = DateTime.Now.ToString ();
			
			Categoria.Save(categoria);			
			
		}
	}

	public class Categoria
	{
		//public int Id {	get; set; }
		private int id;
		private string nombre;

		public int Id {
			get {return id;}
			set {id = value;}
		}

		public string Nombre {
			get {return nombre;}
			set {nombre = value;}
		}
		
		public static Categoria Load(string id) {
			IDbCommand selectDbCommand = App.Instance.DbConnection.CreateCommand ();
			selectDbCommand.CommandText = "select nombre from categoria where id=" + id;
			IDataReader dataReader = selectDbCommand.ExecuteReader();
			dataReader.Read(); //lee el primero

			Categoria categoria = new Categoria();
			categoria.Id = int.Parse (id);
			categoria.Nombre = dataReader["nombre"].ToString();
			
			dataReader.Close ();
			return categoria;
		}
		
		public static void Save(Categoria categoria) {
			IDbCommand updateDbCommand = App.Instance.DbConnection.CreateCommand ();
			updateDbCommand.CommandText = "update categoria set nombre=@nombre where id=" + categoria.Id;
			DbCommandUtil.AddParameter (updateDbCommand, "nombre", categoria.Nombre);
			updateDbCommand.ExecuteNonQuery ();			
		}
		
	}
	
}

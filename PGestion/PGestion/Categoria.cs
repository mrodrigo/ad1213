using System;
using System.Data;
using System.Reflection;

namespace Serpis.Ad
{
	[Table("category")]
	public class Categoria
	{
		//public int Id {	get; set; }
		private int id;
		private string nombre;
		
		[Key]
		public int Id {
			get {return id;}
			set {id = value;}
		}
		
		[Field]
		public string Nombre {
			get {return nombre;}
			set {nombre = value;}
		}
		

		public static object Load(Type type, string id) {
			object obj = Activator.CreateInstance (type);
			
			return obj;
			
		}
		
		public static string GetSelect(Type type) {
			
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
	
	public class FieldAttribute : Attribute 
	{
	}
	
	public class KeyAttribute : Attribute
	{
	}
}


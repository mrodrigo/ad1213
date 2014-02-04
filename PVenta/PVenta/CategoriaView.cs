using System;
using System.Data;

namespace Serpis.Ad
{
	public partial class CategoriaView : Gtk.Window
	{
		public CategoriaView (string id) : base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			
			IDbCommand selectDbCommand = App.Instance.DbConnection.CreateCommand ();
			selectDbCommand.CommandText = "select nombre from categoria where id=" + id;
			IDataReader dataReader = selectDbCommand.ExecuteReader();
			dataReader.Read(); //lee el primero
			entryNombre.Text = dataReader["nombre"].ToString();
			dataReader.Close ();
			saveAction.Activated += delegate {
				IDbCommand updateDbCommand = App.Instance.DbConnection.CreateCommand ();
				updateDbCommand.CommandText = "update categoria set nombre=@nombre where id=" + id;
//				IDbDataParameter nombreDbDataParameter = updateDbCommand.CreateParameter ();
//				nombreDbDataParameter.ParameterName = "nombre";
//				nombreDbDataParameter.Value = entryNombre.Text;
//				updateDbCommand.Parameters.Add(nombreDbDataParameter);
				DbCommandUtil.AddParameter (updateDbCommand, "nombre", entryNombre.Text);
				updateDbCommand.ExecuteNonQuery ();
				
				Destroy ();
				
			};
		}
		
		
	}
}


using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Serpis.Ad
{
	public class ModelHelper
	{
		public static string GetSelect(Type type) {
			string keyName = null;
			List<string> fieldNames = new List<string>();
			foreach (PropertyInfo propertyInfo in type.GetProperties ()) {
				if (propertyInfo.IsDefined (typeof(KeyAttribute), true))
					keyName = propertyInfo.Name.ToLower ();
				else if (propertyInfo.IsDefined (typeof(FieldAttribute), true))
					fieldNames.Add (propertyInfo.Name.ToLower());
			}
			
			string tableName = type.Name.ToLower();
			
			return string.Format ("select {0} from {1} where {2}=",
			                      string.Join(", ", fieldNames), tableName, keyName);
		}

		private static void PutInsert(Type type) {
			List<string> fieldNames = new List<string>();
			foreach (PropertyInfo propertyInfo in type.GetProperties()){
				if(propertyInfo.IsDefined(typeof(FieldAttribute),true))
					fieldNames.Add(propertyInfo.Name.ToLower());
			}
			List<string>tableName = new List<string>();
			foreach (string name in fieldNames){
				tableName.Add("@"+name);
			}
			insertText = string.Format ("INSERT INTO {0} ({1}) values({2})",
				TableName,string.Join(", ", fieldNames),string.Join(", ", tableName));
		}

		private static void PutDelete(Type type) {
			List<string> fieldParameters = new List<string>();
			foreach (int id in FieldNames){
				fieldParameters.Add(formatParameter(id));
			}
			deleteText=string.Format ("DELETE FROM {1} WHERE {2}=",
				tableName,string.Join(", ", fieldParameters), formatParameter(KeyId));
		}
		
		public static object Load(Type type, string id) {
			IDbCommand selectDbCommand = App.Instance.DbConnection.CreateCommand ();
			selectDbCommand.CommandText = GetSelect(type) + id;
			IDataReader dataReader = selectDbCommand.ExecuteReader();
			dataReader.Read(); //lee el primero
			
			object obj = Activator.CreateInstance(type);
			foreach (PropertyInfo propertyInfo in type.GetProperties ()) {
				if (propertyInfo.IsDefined (typeof(KeyAttribute), true))
					propertyInfo.SetValue(obj, id, null); //TODO convert al tipo de destino
				else if (propertyInfo.IsDefined (typeof(FieldAttribute), true))
					propertyInfo.SetValue(obj, dataReader[propertyInfo.Name.ToLower()], null); //TODO convert al tipo de destino
			}
			dataReader.Close ();
			return obj;
		}
		public static void Insert(object obj){
			ModelInfo modelinfo;
		}
	}
}


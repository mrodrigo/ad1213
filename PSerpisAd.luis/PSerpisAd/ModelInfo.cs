using System;

namespace Serpis.Ad
{
	public class ModelInfo
	{

		private Type type;

	


			private string tableName;
			private List<string> fieldNames = new List<string>();
			private List<PropertyInfo> fieldPropertyInfos = new List<PropertyInfo>();
			public ModelInfo(Type type)
			{
				tableName = type.Name.ToLower();
				foreach(PropertyInfo propertyInfo in type.GetProperties()){
					if(propertyInfo.IsDefined(typeof(FieldAttribute),true)){
						fieldPropertyInfos.Add(propertyInfo);
						fieldNames.Add (propertyInfo.Name.ToLower());
					}}
		}
			private void setPutInsert(){
				List<string> parameters = new List<string>();
				foreach(string fieldName in fieldNames)
					parameters.Add("@"+fieldName);
				return string.Format("insert into {0} ({1}) values ({2})",
					tableName,
					string.Join(", ", fieldNames),
					string.Join(", ", fieldNames));
			}
		public string PutInsert{ get { return null; } }
		public PropertyInfo[] fieldsPropertyInfos{ get { return null; } }

	}
}
using System;

namespace Serpis.Ad
{
	public class ModelInfo
	{

		private Type type;

		public string PutInsert{ get { return null; } }
		public PropertyInfo[] PropertyInfoFields{ get { return null; } }

		internal ModelInfo (Type type)
		{
			this.type =type;	
			tableName=type.Name.ToLower();
			fieldPropertyInfos = new List<PropertyInfo>();
			fieldNames = new List<string>();
			foreach (PropertyInfo propertyInfo in type.GetProperties())
				if (propertyInfo.IsDefined(typeof(KeyAttribute),true)){
					keyPropertyInfo = propertyInfo;
					keyName = propertyInfo.Name.ToLower();
				} else if (propertyInfo.IsDefined(typeof(FieldAttribute),true)) {
					fieldPropertyInfos.Add(propertyInfo);
					fieldNames.Add(propertyInfo.Name.ToLower());
				}
			this.PutInsert();
			this.PutDelete();
		}
	}
}
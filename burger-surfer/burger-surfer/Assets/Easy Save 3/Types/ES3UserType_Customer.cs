using System;
using Scripts.UI;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("_isBought")]
	public class ES3UserType_Customer : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Customer() : base(typeof(Customer)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (Customer)obj;
			
			writer.WritePrivateField("_isBought", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (Customer)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "_isBought":
					instance = (Customer)reader.SetPrivateField("_isBought", reader.Read<System.Boolean>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_CustomerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CustomerArray() : base(typeof(Customer[]), ES3UserType_Customer.Instance)
		{
			Instance = this;
		}
	}
}
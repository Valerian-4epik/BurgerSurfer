using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("_playerMoney", "_currentLevel")]
	public class ES3UserType_MoneyInfo : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_MoneyInfo() : base(typeof(MoneyInfo)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (MoneyInfo)obj;
			
			writer.WritePrivateField("_playerMoney", instance);
			writer.WritePrivateField("_currentLevel", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (MoneyInfo)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "_playerMoney":
					instance = (MoneyInfo)reader.SetPrivateField("_playerMoney", reader.Read<System.Int32>(), instance);
					break;
					case "_currentLevel":
					instance = (MoneyInfo)reader.SetPrivateField("_currentLevel", reader.Read<System.Int32>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_MoneyInfoArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_MoneyInfoArray() : base(typeof(MoneyInfo[]), ES3UserType_MoneyInfo.Instance)
		{
			Instance = this;
		}
	}
}
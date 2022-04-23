using System;
using System.Collections;
using System.Data;
using System.Reflection;

namespace SmartZuSoft.SmartTester.Common {
	/// <summary>
	/// Summary description for CommonDefs.
	/// </summary>
	public abstract class PersistentBusinessEntity {
		public const int ID_Empty = -1;
		public static DateTime Date_Empty {
			get {return DateTime.MaxValue;}
		}
	} 

	public class Utility {
		public static DataTable ToDataTable(Array items) {
			DataRow m_Row = null;
			if (items == null) 
				return null;
			if (items.Length == 0)
				return null;

			DataTable r_DataTable = new DataTable("Cathegory");

			// экземпляр коллекции
			object item = items.GetValue(0);
			Type i_Type = item.GetType();
			FieldInfo[] fields = i_Type.GetFields(BindingFlags.NonPublic
				| BindingFlags.Public
				| BindingFlags.Instance
				| BindingFlags.Static);
			ArrayList pKeys = new ArrayList();
			foreach (FieldInfo f in fields) {
				DataColumn dCol = new DataColumn();
				dCol.ColumnName = f.Name;
				dCol.Caption    = f.Name;
				dCol.DataType   = f.FieldType;
				// ключевое поле
				KeyFieldAttribute[] attrList = (KeyFieldAttribute[])f.GetCustomAttributes(typeof(KeyFieldAttribute), true);
//				if (attrList != null)
					if (attrList.Length > 0)
						if(attrList[0].IsPrimaryKey) {
							dCol.AllowDBNull = false;
							pKeys.Add(dCol);
						}
				// имя 
				FieldCaptionAttribute[] attrCList = (FieldCaptionAttribute[])f.GetCustomAttributes(typeof(FieldCaptionAttribute), true);
				//				if (attrList != null)
				if (attrCList.Length > 0)
					dCol.Caption = attrCList[0].Caption;

				r_DataTable.Columns.Add(dCol);
			}
			if (pKeys.Count > 0) {
				DataColumn[] pKeyColumns = new DataColumn[pKeys.Count];
				pKeys.CopyTo(pKeyColumns);
				r_DataTable.PrimaryKey = pKeyColumns;
			}

			// данные
			foreach (object obj in items) {
				m_Row = r_DataTable.NewRow();
				foreach (FieldInfo f in fields) {
					string f_name = f.Name;
					m_Row[f_name] = f.GetValue(obj);
				}
				r_DataTable.Rows.Add(m_Row);
			}
			return r_DataTable;
		}
	}
	
	[AttributeUsage(AttributeTargets.Field)]
	public class KeyFieldAttribute :Attribute {
		private bool _isPrimaryKey;

		public bool IsPrimaryKey {
			get {return _isPrimaryKey;}
			set {_isPrimaryKey = value;}
		}

		public KeyFieldAttribute(bool isPrimaryKey) {
			_isPrimaryKey = isPrimaryKey;
		}
	}

	[AttributeUsage(AttributeTargets.Field)]
	public class FieldCaptionAttribute :Attribute {
		private string _caption;

		public string Caption {
			get {return _caption;}
			set {_caption = value;}
		}

		public FieldCaptionAttribute(string caption) {
			_caption = caption;
		}
	}
}

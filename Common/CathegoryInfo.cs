using System;
using System.Data;

namespace SmartZuSoft.SmartTester.Common {
	/// <summary>
	/// BusinessEntity: Cathegory
	/// </summary>
	public class CathegoryInfo{
		#region private
		[KeyField(true)][FieldCaption("ID")]
		private int cathegory_ID;
		
		[FieldCaption("№")]
		private int number;
		
		[FieldCaption("Наименование")]
		private string name;
		#endregion
		
		#region Properties
		public int CathegoryID {
			get { return cathegory_ID; }
			set { cathegory_ID = value; }
		}

		public int Number {
			get { return number; }
			set { number = value; }
		}

		public string Name {
			get { return name; }
			set { name = value; }
		}

		#endregion

		public CathegoryInfo() {
			CathegoryID = PersistentBusinessEntity.ID_Empty;
		}

	}

	
}

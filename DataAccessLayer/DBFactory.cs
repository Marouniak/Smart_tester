using System;
using SmartZuSoft.SmartTester.Common;

namespace SmartZuSoft.SmartTester.DAL {

	public class DBFactory {
		private const String Filter = "@filterClause";
		private const String Order = "@orderClause";

		
		public DBFactory() {
		}

		/// <summary>
		/// Возвращает строку соединения с базой
		/// </summary>
		/// <returns>строка соединения с БД</returns>
		public static string ConnectionString() {
			//return AppConfig.dbConnString;

			//FOR FireBird
			return "User=SYSDBA;"				+
				"Password=masterkey;"			+
				"Database=E:\\DataBase\\SmartTester\\smarttester.gdb;" +
				"DataSource=limpopo;"			+
				"Port=3050;"					+
				"Dialect=3;"					+
				"Charset=WIN1251;"					+
				"Role=admin;"						+
				"Connection lifetime=15;"		+
				"Pooling=true;"					+
				"Packet Size=8192";
			
			
			//FOR MS SQL
			//return "User ID=zu;Password=zu;Persist Security Info=True;Initial Catalog=ZuLIfe;Data Source=LIMPOPO;Packet Size=4096;Workstation ID=LIMPOPO;";
		}
	}
}

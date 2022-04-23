using System;

using SmartZuSoft.SmartTester.Common;
using SmartZuSoft.SmartTester.DAL;


namespace SmartZuSoft.SmartTester.BusinessRules {

	public class Cathegory {

		public CathegoryInfo[] GetItemList(FilterExpression filter, OrderExpression order) {
			CathegoryInfo[] items  = null;
			using (CathegoryDAL cDal = new CathegoryDAL()) {
				items = cDal.GetCathegories(filter, order);
			}
			return items;
		}


		public CathegoryInfo[] GetItemList() {
			return GetItemList(null, null);
		}

	
		public CathegoryInfo GetInfo(int cathegoryID) {
			CathegoryInfo item = null;
			using (CathegoryDAL cDAL = new CathegoryDAL()) {
				item = cDAL.GetCathegoryInfo(cathegoryID);
			}
			return item;
		}


		public bool Add(CathegoryInfo item, out int cathegoryID) {
			bool res = false;
			using (CathegoryDAL cDAL = new CathegoryDAL()) {
				res = cDAL.AddCathegory(item, out cathegoryID);
			}
			return res;
		}


		public bool Update(CathegoryInfo item) {
			bool res = false;
			using (CathegoryDAL cDAL = new CathegoryDAL()) {
				res = cDAL.UpdateCathegoryInfo(item);
			}
			return res;
		}


		public bool Delete(int cathegoryID) {
			bool res = false;
			using (CathegoryDAL cDAL = new CathegoryDAL()) {
				res = cDAL.DeleteCathegory(cathegoryID);
			}
			return res;
		}


	}
}

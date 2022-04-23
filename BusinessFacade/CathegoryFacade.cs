using System;

using SmartZuSoft.SmartTester.Common;
using SmartZuSoft.SmartTester.BusinessRules;

namespace SmartZuSoft.SmartTester.BusinessFacade {

	public class CathegoryFacade {
		public CathegoryInfo[] GetItemList(FilterExpression filter, OrderExpression order) {
			Cathegory rule = new Cathegory();
			return rule.GetItemList(filter, order);
		}


		public CathegoryInfo[] GetItemList() {
			Cathegory rule = new Cathegory();
			return rule.GetItemList();
		}

		public CathegoryInfo GetCathegoryInfo(int cathegoryID) {
			Cathegory rule = new Cathegory();
			return rule.GetInfo(cathegoryID);
		}

		public bool Add(CathegoryInfo ci, out int cathegoryID) {
			Cathegory rule = new Cathegory();
			return rule.Add(ci, out cathegoryID);
		}

		public bool Update(CathegoryInfo ci) {
			Cathegory rule = new Cathegory();
			return rule.Update(ci);
		}

		public bool Delete(int cathegoryID) {
			Cathegory rule = new Cathegory();
			return rule.Delete(cathegoryID);
		}
		
	}
}

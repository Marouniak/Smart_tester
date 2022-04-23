using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using SmartZuSoft.SmartTester.BusinessFacade;
using SmartZuSoft.SmartTester.Common;
using SourceGrid2;


namespace SmartZuSoft.SmartTester.WinApp {
	public class CathegoryList : SmartZuSoft.SmartTester.WinApp.frmListBase {
		private System.ComponentModel.IContainer components = null;
		private CathegoryFacade facade;
		public static CathegoryList childForm;

		public CathegoryList() {
			InitializeComponent();
			facade = new CathegoryFacade();
			LoadData();
		}


		protected override void LoadData() {
			CathegoryInfo[] items = facade.GetItemList();
			System.Data.DataTable table = SmartTester.Common.Utility.ToDataTable(items);
			dgItems.LoadDataSource(table);
		}


		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CathegoryList));
			// 
			// pnBottom
			// 
			this.pnBottom.Name = "pnBottom";
			// 
			// btnClose
			// 
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Name = "btnClose";
			// 
			// btnOK
			// 
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOK.Name = "btnOK";
			// 
			// miAddItem
			// 
			this.menuExtender.SetExtEnable(this.miAddItem, true);
			this.menuExtender.SetImageIndex(this.miAddItem, 0);
			this.miAddItem.Click += new System.EventHandler(this.miAddItem_Click);
			// 
			// miDelete
			// 
			this.menuExtender.SetExtEnable(this.miDelete, true);
			this.menuExtender.SetImageIndex(this.miDelete, 2);
			this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
			// 
			// miEdit
			// 
			this.menuExtender.SetExtEnable(this.miEdit, true);
			this.menuExtender.SetImageIndex(this.miEdit, 1);
			this.miEdit.Click += new System.EventHandler(this.miEdit_Click);
			// 
			// dgItems
			// 
			this.dgItems.Name = "dgItems";
			// 
			// cmiAdd
			// 
			this.menuExtender.SetExtEnable(this.cmiAdd, true);
			this.menuExtender.SetImageIndex(this.cmiAdd, 0);
			this.cmiAdd.Click += new System.EventHandler(this.miAddItem_Click);
			// 
			// cmiEdit
			// 
			this.menuExtender.SetExtEnable(this.cmiEdit, true);
			this.menuExtender.SetImageIndex(this.cmiEdit, 1);
			this.cmiEdit.Click += new System.EventHandler(this.miEdit_Click);
			// 
			// cmiDelete
			// 
			this.menuExtender.SetExtEnable(this.cmiDelete, true);
			this.menuExtender.SetImageIndex(this.cmiDelete, 2);
			this.cmiDelete.Click += new System.EventHandler(this.miDelete_Click);
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			// 
			// CathegoryList
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(520, 221);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CathegoryList";
			this.Text = "Категории тестов";
			this.Closed += new System.EventHandler(this.CathegoryList_Closed);

		}
		#endregion

		private void CathegoryList_Closed(object sender, System.EventArgs e) {
			childForm = null;
		}

		public static CathegoryList GetInstance() {
			if(childForm == null)
				childForm = new CathegoryList();
			return childForm;
		}

		private void miDelete_Click(object sender, System.EventArgs e) {
			if (CurrentPrimaryKeyValue == null)
				return;

			if (MessageBox.Show(this, "Удалить текущую запись?","Предупреждение", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				int cathegoryID = (int)CurrentPrimaryKeyValue;
//				MessageBox.Show(this,"", cathegoryID.ToString(), MessageBoxButtons.OK);
				facade.Delete(cathegoryID);
				LoadData();
			}
		}

		private void miAddItem_Click(object sender, System.EventArgs e) {
			CathegoryDialog frm = new CathegoryDialog();
			frm.ShowDialog();
			LoadData();
		}

		private void miEdit_Click(object sender, System.EventArgs e) {
			if (CurrentPrimaryKeyValue == null)
				return;

			int cathegoryID = (int)CurrentPrimaryKeyValue;
			CathegoryDialog frm = new CathegoryDialog(cathegoryID);
			frm.ShowDialog();
			LoadData();
		}
	}
}


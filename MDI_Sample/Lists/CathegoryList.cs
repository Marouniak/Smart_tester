using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SmartZuSoft.SmartTester.MDI {
	public class CathegoryList : SmartZuSoft.SmartTester.MDI.frmListBase {
		private System.ComponentModel.IContainer components = null;
		public static CathegoryList childForm;

		public CathegoryList() {
			InitializeComponent();
			LoadData();
		}


		protected override void LoadData() {
			daItem.Fill(dsItem);
			dwItem.Table = dsItem.Tables[0];
			dgItem.DataSource = dwItem;
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
			((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgItem)).BeginInit();
			// 
			// pnBottom
			// 
			this.pnBottom.Name = "pnBottom";
			// 
			// cmdUpdate
			// 
			this.cmdUpdate.CommandText = "UPDATE CATHEGORY SET Number=@NUMBER,Name=@NAME WHERE (CATHEGORY_ID=@CATHEGORY_ID)" +
				"";
			this.cmdUpdate.Parameters.Add(new FirebirdSql.Data.Firebird.FbParameter("CATHEGORY_ID", FirebirdSql.Data.Firebird.FbDbType.Integer));
			this.cmdUpdate.Parameters.Add(new FirebirdSql.Data.Firebird.FbParameter("Number", FirebirdSql.Data.Firebird.FbDbType.Integer));
			this.cmdUpdate.Parameters.Add(new FirebirdSql.Data.Firebird.FbParameter("Name", FirebirdSql.Data.Firebird.FbDbType.VarChar));
			// 
			// cmdInsert
			// 
			this.cmdInsert.CommandText = "INSERT INTO CATHEGORY(NUMBER,NAME) VALUES(@Number,@Name)";
			this.cmdInsert.Parameters.Add(new FirebirdSql.Data.Firebird.FbParameter("CATHEGORY_ID", FirebirdSql.Data.Firebird.FbDbType.Integer));
			this.cmdInsert.Parameters.Add(new FirebirdSql.Data.Firebird.FbParameter("Number", FirebirdSql.Data.Firebird.FbDbType.VarChar));
			this.cmdInsert.Parameters.Add(new FirebirdSql.Data.Firebird.FbParameter("Name", FirebirdSql.Data.Firebird.FbDbType.VarChar));
			// 
			// cmdDelete
			// 
			this.cmdDelete.CommandText = "DELETE FROM CATHEGORY\r\nWHERE CATHEGORY_ID=@CATHEGORY_ID";
			this.cmdDelete.Parameters.Add(new FirebirdSql.Data.Firebird.FbParameter("CATHEGORY_ID", FirebirdSql.Data.Firebird.FbDbType.Integer));
			// 
			// cmdSelect
			// 
			this.cmdSelect.CommandText = "SELECT * FROM CATHEGORY";
			// 
			// dgItem
			// 
			this.dgItem.Name = "dgItem";
			// 
			// btnClose
			// 
			this.btnClose.Name = "btnClose";
			// 
			// btnOK
			// 
			this.btnOK.Name = "btnOK";
			// 
			// miDelete
			// 
			this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
			// 
			// CathegoryList
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(520, 221);
			this.Name = "CathegoryList";
			this.Text = "Категории тестов";
			this.Closed += new System.EventHandler(this.CathegoryList_Closed);
			((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgItem)).EndInit();

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
			if (MessageBox.Show(this, "Удалить текущую запись?","Предупреждение", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				BindingManagerBase bmGrid = BindingContext[dwItem, ""];
				dwItem.Delete(bmGrid.Position);
//				dsItem.Tables[0].Rows.RemoveAt(bmGrid.Position); 
//				dsItem.Tables[0].Rows[bmGrid.Position].Delete();
//				dsItem.AcceptChanges();
//				int rowcount = daItem.Update(dsItem.Tables[0]);
//				MessageBox.Show(this, rowcount.ToString(),"Предупреждение", MessageBoxButtons.OK);
			}
		}
	}
}


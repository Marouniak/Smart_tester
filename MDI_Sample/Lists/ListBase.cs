using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SmartZuSoft.SmartTester.MDI {
	/// <summary>
	/// Summary description for ListBase.
	/// </summary>
	public class frmListBase : System.Windows.Forms.Form {
		protected System.Windows.Forms.Panel pnBottom;
		protected FirebirdSql.Data.Firebird.FbDataAdapter daItem;
		protected System.Data.DataSet dsItem;
		protected FirebirdSql.Data.Firebird.FbCommand cmdUpdate;
		protected FirebirdSql.Data.Firebird.FbCommand cmdInsert;
		protected FirebirdSql.Data.Firebird.FbCommand cmdDelete;
		protected FirebirdSql.Data.Firebird.FbCommand cmdSelect;
		protected System.Windows.Forms.DataGrid dgItem;
		protected System.Windows.Forms.Button btnClose;
		protected System.Windows.Forms.Button btnOK;
		protected FirebirdSql.Data.Firebird.FbConnection conn;
		protected System.Windows.Forms.MainMenu itemMenu;
		protected System.Windows.Forms.MenuItem miActions;
		protected System.Windows.Forms.MenuItem miAddItem;
		protected System.Windows.Forms.MenuItem miDelete;
		protected System.Windows.Forms.MenuItem miEdit;
		protected System.Data.DataView dwItem;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmListBase() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.dgItem = new System.Windows.Forms.DataGrid();
			this.pnBottom = new System.Windows.Forms.Panel();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.daItem = new FirebirdSql.Data.Firebird.FbDataAdapter();
			this.cmdDelete = new FirebirdSql.Data.Firebird.FbCommand();
			this.conn = new FirebirdSql.Data.Firebird.FbConnection();
			this.cmdInsert = new FirebirdSql.Data.Firebird.FbCommand();
			this.cmdSelect = new FirebirdSql.Data.Firebird.FbCommand();
			this.cmdUpdate = new FirebirdSql.Data.Firebird.FbCommand();
			this.dsItem = new System.Data.DataSet();
			this.itemMenu = new System.Windows.Forms.MainMenu();
			this.miActions = new System.Windows.Forms.MenuItem();
			this.miAddItem = new System.Windows.Forms.MenuItem();
			this.miEdit = new System.Windows.Forms.MenuItem();
			this.miDelete = new System.Windows.Forms.MenuItem();
			this.dwItem = new System.Data.DataView();
			((System.ComponentModel.ISupportInitialize)(this.dgItem)).BeginInit();
			this.pnBottom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dsItem)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dwItem)).BeginInit();
			this.SuspendLayout();
			// 
			// dgItem
			// 
			this.dgItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dgItem.DataMember = "";
			this.dgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgItem.Location = new System.Drawing.Point(0, 0);
			this.dgItem.Name = "dgItem";
			this.dgItem.Size = new System.Drawing.Size(520, 192);
			this.dgItem.TabIndex = 0;
			this.dgItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgItem_MouseUp);
			// 
			// pnBottom
			// 
			this.pnBottom.Controls.Add(this.btnOK);
			this.pnBottom.Controls.Add(this.btnClose);
			this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnBottom.Location = new System.Drawing.Point(0, 197);
			this.pnBottom.Name = "pnBottom";
			this.pnBottom.Size = new System.Drawing.Size(520, 24);
			this.pnBottom.TabIndex = 1;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(360, 0);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(80, 24);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "ОК";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Location = new System.Drawing.Point(440, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(80, 24);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Закрыть";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// daItem
			// 
			this.daItem.DeleteCommand = this.cmdDelete;
			this.daItem.InsertCommand = this.cmdInsert;
			this.daItem.SelectCommand = this.cmdSelect;
			this.daItem.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							 new System.Data.Common.DataTableMapping("Table", "Table", new System.Data.Common.DataColumnMapping[0])});
			this.daItem.UpdateCommand = this.cmdUpdate;
			this.daItem.RowUpdating += new FirebirdSql.Data.Firebird.FbRowUpdatingEventHandler(this.daItem_RowUpdating);
			// 
			// cmdDelete
			// 
			this.cmdDelete.Connection = this.conn;
			// 
			// conn
			// 
			this.conn.ConnectionString = "User=SYSDBA;Password=masterkey;Database=E:\\DataBase\\SmartTester\\SMARTTESTER.GDB;D" +
				"ataSource=local;Port=3050;Dialect=3;Charset=WIN1251;Role=admin;Connection lifeti" +
				"me=0;Connection timeout=15;Pooling=True;Packet Size=8192;Server Type=0";
			// 
			// cmdInsert
			// 
			this.cmdInsert.Connection = this.conn;
			// 
			// cmdSelect
			// 
			this.cmdSelect.Connection = this.conn;
			// 
			// cmdUpdate
			// 
			this.cmdUpdate.Connection = this.conn;
			// 
			// dsItem
			// 
			this.dsItem.DataSetName = "dsItem";
			this.dsItem.Locale = new System.Globalization.CultureInfo("ru-RU");
			// 
			// itemMenu
			// 
			this.itemMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.miActions});
			// 
			// miActions
			// 
			this.miActions.Index = 0;
			this.miActions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.miAddItem,
																					  this.miEdit,
																					  this.miDelete});
			this.miActions.Text = "Действия";
			// 
			// miAddItem
			// 
			this.miAddItem.Index = 0;
			this.miAddItem.Text = "Добавить";
			// 
			// miEdit
			// 
			this.miEdit.Index = 1;
			this.miEdit.Text = "Изменить";
			// 
			// miDelete
			// 
			this.miDelete.Index = 2;
			this.miDelete.Text = "Удалить";
			this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
			// 
			// frmListBase
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(520, 221);
			this.Controls.Add(this.pnBottom);
			this.Controls.Add(this.dgItem);
			this.Menu = this.itemMenu;
			this.Name = "frmListBase";
			this.ShowInTaskbar = false;
			this.Text = "ListBase";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListBase_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgItem)).EndInit();
			this.pnBottom.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dsItem)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dwItem)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		
		protected virtual void LoadData() {
		}


		private void frmListBase_Load(object sender, System.EventArgs e) {
//			conn.ConnectionString = AppConfig.ConnectionString;
		}

		private void btnOK_Click(object sender, System.EventArgs e) {
			Close();
		}

		private void btnClose_Click(object sender, System.EventArgs e) {
			Close();
		}

		private void miDelete_Click(object sender, System.EventArgs e) {
//			if (MessageBox.Show(this, "Удалить текущую запись?","Предупреждение", MessageBoxButtons.YesNo) == DialogResult.Yes) {
//				BindingManagerBase bmGrid = BindingContext[dsItem.Tables[0], ""];
//				dsItem.Tables[0].Rows.RemoveAt(bmGrid.Position); 
////				dsItem.Tables[0].Rows[bmGrid.Position].Delete();
//				dsItem.AcceptChanges();
//				int rowcount = daItem.Update(dsItem);
//				MessageBox.Show(this, rowcount.ToString(),"Предупреждение", MessageBoxButtons.OK);
//			}

		}

		private void dgItem_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e) {
			System.Drawing.Point pt = new Point(e.X, e.Y);
			DataGrid.HitTestInfo hti = dgItem.HitTest(pt);
			if(hti.Type == DataGrid.HitTestType.Cell) {
				dgItem.CurrentCell = new DataGridCell(hti.Row, hti.Column);
				dgItem.Select(hti.Row);
			}
		}

		private void daItem_RowUpdating(object sender, FirebirdSql.Data.Firebird.FbRowUpdatingEventArgs e) {
//			int i=0;
//			int a=i+1;
		}

	}
}

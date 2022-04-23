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
	/// <summary>
	/// Summary description for ListBase.
	/// </summary>
	public class frmListBase : System.Windows.Forms.Form {
		protected System.Windows.Forms.Panel pnBottom;
		protected System.Windows.Forms.Button btnClose;
		protected System.Windows.Forms.Button btnOK;
		protected System.Windows.Forms.MainMenu itemMenu;
		protected System.Windows.Forms.MenuItem miActions;
		protected System.Windows.Forms.MenuItem miAddItem;
		protected System.Windows.Forms.MenuItem miDelete;
		protected System.Windows.Forms.MenuItem miEdit;
		protected SmartZuSoft.SmartTester.Components.GridDataTable dgItems;
		protected System.Windows.Forms.ContextMenu itemContMenu;
		protected System.Windows.Forms.MenuItem cmiAdd;
		protected System.Windows.Forms.MenuItem cmiEdit;
		protected System.Windows.Forms.MenuItem cmiDelete;
		protected System.Windows.Forms.ImageList imageList;
		protected MenuExtender.MenuExtender menuExtender;
		private System.ComponentModel.IContainer components;

		public frmListBase() {
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public object CurrentPrimaryKeyValue {
			get {
				if (dgItems.RowsCount == 0) 
					return null;

				DataRow currRow = (System.Data.DataRow)(dgItems.FocusDataRow);
				if (currRow == null)
					return null;

				DataColumn pKey = dgItems.DataTable.PrimaryKey[0];
				if (pKey == null)
					return null;
				
				return currRow[pKey];
			}
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmListBase));
			this.pnBottom = new System.Windows.Forms.Panel();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.itemMenu = new System.Windows.Forms.MainMenu();
			this.miActions = new System.Windows.Forms.MenuItem();
			this.miAddItem = new System.Windows.Forms.MenuItem();
			this.miEdit = new System.Windows.Forms.MenuItem();
			this.miDelete = new System.Windows.Forms.MenuItem();
			this.dgItems = new SmartZuSoft.SmartTester.Components.GridDataTable();
			this.itemContMenu = new System.Windows.Forms.ContextMenu();
			this.cmiAdd = new System.Windows.Forms.MenuItem();
			this.cmiEdit = new System.Windows.Forms.MenuItem();
			this.cmiDelete = new System.Windows.Forms.MenuItem();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.menuExtender = new MenuExtender.MenuExtender(this.components);
			this.pnBottom.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnBottom
			// 
			this.pnBottom.Controls.Add(this.btnOK);
			this.pnBottom.Controls.Add(this.btnClose);
			this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnBottom.Location = new System.Drawing.Point(0, 249);
			this.pnBottom.Name = "pnBottom";
			this.pnBottom.Size = new System.Drawing.Size(544, 24);
			this.pnBottom.TabIndex = 1;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(384, 0);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(80, 24);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "ОК";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Location = new System.Drawing.Point(464, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(80, 24);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Закрыть";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
			this.menuExtender.SetExtEnable(this.miAddItem, true);
			this.menuExtender.SetImageIndex(this.miAddItem, 0);
			this.miAddItem.Index = 0;
			this.miAddItem.OwnerDraw = true;
			this.miAddItem.Shortcut = System.Windows.Forms.Shortcut.Ins;
			this.miAddItem.Text = "Добавить";
			// 
			// miEdit
			// 
			this.menuExtender.SetExtEnable(this.miEdit, true);
			this.menuExtender.SetImageIndex(this.miEdit, 1);
			this.miEdit.Index = 1;
			this.miEdit.OwnerDraw = true;
			this.miEdit.Shortcut = System.Windows.Forms.Shortcut.F2;
			this.miEdit.Text = "Изменить";
			// 
			// miDelete
			// 
			this.menuExtender.SetExtEnable(this.miDelete, true);
			this.menuExtender.SetImageIndex(this.miDelete, 2);
			this.miDelete.Index = 2;
			this.miDelete.OwnerDraw = true;
			this.miDelete.Shortcut = System.Windows.Forms.Shortcut.Del;
			this.miDelete.Text = "Удалить";
			this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
			// 
			// dgItems
			// 
			this.dgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dgItems.AutoSizeMinHeight = 10;
			this.dgItems.AutoSizeMinWidth = 10;
			this.dgItems.AutoStretchColumnsToFitWidth = true;
			this.dgItems.AutoStretchRowsToFitHeight = false;
			this.dgItems.ContextMenu = this.itemContMenu;
			this.dgItems.ContextMenuStyle = SourceGrid2.ContextMenuStyle.None;
			this.dgItems.EnableDelete = false;
			this.dgItems.EnableEdit = true;
			this.dgItems.GridToolTipActive = true;
			this.dgItems.Location = new System.Drawing.Point(0, 0);
			this.dgItems.Name = "dgItems";
			this.dgItems.Size = new System.Drawing.Size(552, 244);
			this.dgItems.SpecialKeys = SourceGrid2.GridSpecialKeys.Arrows;
			this.dgItems.TabIndex = 2;
			// 
			// itemContMenu
			// 
			this.itemContMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.cmiAdd,
																						 this.cmiEdit,
																						 this.cmiDelete});
			// 
			// cmiAdd
			// 
			this.menuExtender.SetExtEnable(this.cmiAdd, true);
			this.menuExtender.SetImageIndex(this.cmiAdd, 0);
			this.cmiAdd.Index = 0;
			this.cmiAdd.OwnerDraw = true;
			this.cmiAdd.Text = "Добавить";
			// 
			// cmiEdit
			// 
			this.menuExtender.SetExtEnable(this.cmiEdit, true);
			this.menuExtender.SetImageIndex(this.cmiEdit, 1);
			this.cmiEdit.Index = 1;
			this.cmiEdit.OwnerDraw = true;
			this.cmiEdit.Text = "Изменить";
			// 
			// cmiDelete
			// 
			this.menuExtender.SetExtEnable(this.cmiDelete, true);
			this.menuExtender.SetImageIndex(this.cmiDelete, 2);
			this.cmiDelete.Index = 2;
			this.cmiDelete.OwnerDraw = true;
			this.cmiDelete.Text = "Удалить";
			this.cmiDelete.Click += new System.EventHandler(this.miDelete_Click);
			// 
			// imageList
			// 
			this.imageList.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// menuExtender
			// 
			this.menuExtender.Font = null;
			this.menuExtender.ImageList = this.imageList;
			this.menuExtender.SystemFont = true;
			// 
			// frmListBase
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(544, 273);
			this.Controls.Add(this.dgItems);
			this.Controls.Add(this.pnBottom);
			this.Menu = this.itemMenu;
			this.Name = "frmListBase";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ListBase";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmListBase_Load);
			this.pnBottom.ResumeLayout(false);
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

		}


	}
}

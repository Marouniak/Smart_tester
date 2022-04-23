using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using SmartZuSoft.SmartTester.BusinessFacade;
using SmartZuSoft.SmartTester.Common;

namespace SmartZuSoft.SmartTester.WinApp {
	/// <summary>
	/// Summary description for Test1.
	/// </summary>
	public class Test1 : System.Windows.Forms.Form {
		private SmartZuSoft.SmartTester.Components.GridDataTable dgCathegories;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Test1() {
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
			this.dgCathegories = new SmartZuSoft.SmartTester.Components.GridDataTable();
			this.SuspendLayout();
			// 
			// dgCathegories
			// 
			this.dgCathegories.AutoSizeMinHeight = 10;
			this.dgCathegories.AutoSizeMinWidth = 10;
			this.dgCathegories.AutoStretchColumnsToFitWidth = false;
			this.dgCathegories.AutoStretchRowsToFitHeight = false;
			this.dgCathegories.ContextMenuStyle = SourceGrid2.ContextMenuStyle.None;
			this.dgCathegories.EnableEdit = true;
			this.dgCathegories.GridToolTipActive = true;
			this.dgCathegories.Location = new System.Drawing.Point(8, 8);
			this.dgCathegories.Name = "dgCathegories";
			this.dgCathegories.Size = new System.Drawing.Size(496, 200);
			this.dgCathegories.SpecialKeys = SourceGrid2.GridSpecialKeys.Default;
			this.dgCathegories.TabIndex = 0;
			// 
			// Test1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(512, 273);
			this.Controls.Add(this.dgCathegories);
			this.Name = "Test1";
			this.Text = "Test1";
			this.Load += new System.EventHandler(this.Test1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void Test1_Load(object sender, System.EventArgs e) {
			CathegoryFacade facade = new CathegoryFacade();
			CathegoryInfo[] items = facade.GetItemList();
			System.Data.DataTable table = SmartTester.Common.Utility.ToDataTable(items);
			dgCathegories.LoadDataSource(table);
		}
	}
}

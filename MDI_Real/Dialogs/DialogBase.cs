using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using SmartZuSoft.SmartTester.Common;
using SmartZuSoft.SmartTester.BusinessFacade;

namespace SmartZuSoft.SmartTester.WinApp {
	/// <summary>
	/// Summary description for DialogBase.
	/// </summary>
	public class frmDialogBase : System.Windows.Forms.Form {
		protected System.Windows.Forms.Panel pnBottom;
		protected System.Windows.Forms.Button btnOK;
		protected System.Windows.Forms.Button btnClose;
		private object _primaryKey;
		const ModifierKey MODIFIERS = ModifierKey.MOD_ALT | ModifierKey.MOD_CONTROL | ModifierKey.MOD_SHIFT;
		const Keys VIRTUAL_KEY = Keys.D1;


		protected object PrimaryKey {
			get {return _primaryKey;}
			set {_primaryKey = value;}
		}

		public bool IsNewItem {
			get {
				return _primaryKey == null ? true : false;
			}
		}
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDialogBase() {
			InitializeComponent();
			
			_primaryKey = null;
		}

		public frmDialogBase(object pKey) {
			InitializeComponent();
			_primaryKey = pKey;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			HotKeyHelper.Instance.UnRegister();
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
			this.pnBottom = new System.Windows.Forms.Panel();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.pnBottom.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnBottom
			// 
			this.pnBottom.Controls.Add(this.btnOK);
			this.pnBottom.Controls.Add(this.btnClose);
			this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnBottom.Location = new System.Drawing.Point(0, 191);
			this.pnBottom.Name = "pnBottom";
			this.pnBottom.Size = new System.Drawing.Size(362, 24);
			this.pnBottom.TabIndex = 2;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOK.Location = new System.Drawing.Point(202, 0);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(80, 24);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "ОК";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Location = new System.Drawing.Point(282, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(80, 24);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Закрыть";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// frmDialogBase
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(362, 215);
			this.Controls.Add(this.pnBottom);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmDialogBase";
			this.Text = "DialogBase";
			this.pnBottom.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		protected virtual void DataBind() {
		}

		private void btnClose_Click(object sender, System.EventArgs e) {
			Close();
		}

		protected virtual void btnOK_Click(object sender, System.EventArgs e) {
		
		}

	}
}

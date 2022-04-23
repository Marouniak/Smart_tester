using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SmartZuSoft.SmartTester.Common;
using SmartZuSoft.SmartTester.BusinessFacade;


namespace SmartZuSoft.SmartTester.WinApp {
	public class CathegoryDialog : SmartZuSoft.SmartTester.WinApp.frmDialogBase {
		private System.Windows.Forms.Label l_ID;
		private System.Windows.Forms.Label l_Number;
		private System.Windows.Forms.Label l_Name;
		private SourceLibrary.Windows.Forms.TextBoxTypedNumeric tbNumber;
		private SourceLibrary.Windows.Forms.TextBoxTypedNumeric tbID;
		private SourceLibrary.Windows.Forms.TextBoxTyped tbName;
		private System.ComponentModel.IContainer components = null;

		public CathegoryDialog() {
			InitializeComponent();
			PrimaryKey = null;
			DataBind();
		}

		public CathegoryDialog(object pKey) {
			InitializeComponent();
			PrimaryKey = pKey;
			DataBind();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CathegoryDialog));
			this.tbNumber = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
			this.tbID = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
			this.tbName = new SourceLibrary.Windows.Forms.TextBoxTyped();
			this.l_ID = new System.Windows.Forms.Label();
			this.l_Number = new System.Windows.Forms.Label();
			this.l_Name = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// pnBottom
			// 
			this.pnBottom.Location = new System.Drawing.Point(0, 79);
			this.pnBottom.Name = "pnBottom";
			this.pnBottom.Size = new System.Drawing.Size(378, 24);
			this.pnBottom.TabIndex = 6;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(216, 0);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 0;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(296, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.TabIndex = 1;
			// 
			// tbNumber
			// 
			this.tbNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbNumber.EnableAutoValidation = true;
			this.tbNumber.EnableEnterKeyValidate = true;
			this.tbNumber.EnableEscapeKeyUndo = true;
			this.tbNumber.EnableLastValidValue = true;
			this.tbNumber.ErrorProvider = null;
			this.tbNumber.ErrorProviderMessage = "Invalid value";
			this.tbNumber.ForceFormatText = true;
			this.tbNumber.Location = new System.Drawing.Point(268, 8);
			this.tbNumber.Name = "tbNumber";
			this.tbNumber.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
			this.tbNumber.ReadOnly = true;
			this.tbNumber.TabIndex = 3;
			this.tbNumber.Text = "";
			this.tbNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tbID
			// 
			this.tbID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbID.EnableAutoValidation = true;
			this.tbID.EnableEnterKeyValidate = true;
			this.tbID.EnableEscapeKeyUndo = true;
			this.tbID.EnableLastValidValue = true;
			this.tbID.ErrorProvider = null;
			this.tbID.ErrorProviderMessage = "Invalid value";
			this.tbID.ForceFormatText = true;
			this.tbID.Location = new System.Drawing.Point(88, 8);
			this.tbID.Name = "tbID";
			this.tbID.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
			this.tbID.ReadOnly = true;
			this.tbID.TabIndex = 2;
			this.tbID.Text = "";
			this.tbID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tbName
			// 
			this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbName.EnableAutoValidation = true;
			this.tbName.EnableEnterKeyValidate = true;
			this.tbName.EnableEscapeKeyUndo = true;
			this.tbName.EnableLastValidValue = true;
			this.tbName.ErrorProvider = null;
			this.tbName.ErrorProviderMessage = "Invalid value";
			this.tbName.ForceFormatText = true;
			this.tbName.Location = new System.Drawing.Point(88, 43);
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(280, 20);
			this.tbName.TabIndex = 1;
			this.tbName.Text = "";
			// 
			// l_ID
			// 
			this.l_ID.Location = new System.Drawing.Point(0, 11);
			this.l_ID.Name = "l_ID";
			this.l_ID.Size = new System.Drawing.Size(72, 20);
			this.l_ID.TabIndex = 4;
			this.l_ID.Text = "ID";
			// 
			// l_Number
			// 
			this.l_Number.Location = new System.Drawing.Point(232, 11);
			this.l_Number.Name = "l_Number";
			this.l_Number.Size = new System.Drawing.Size(32, 20);
			this.l_Number.TabIndex = 7;
			this.l_Number.Text = "№";
			// 
			// l_Name
			// 
			this.l_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
			this.l_Name.ForeColor = System.Drawing.Color.DarkMagenta;
			this.l_Name.Location = new System.Drawing.Point(0, 46);
			this.l_Name.Name = "l_Name";
			this.l_Name.Size = new System.Drawing.Size(88, 16);
			this.l_Name.TabIndex = 5;
			this.l_Name.Text = "Наименование";
			// 
			// CathegoryDialog
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(378, 103);
			this.Controls.Add(this.l_Name);
			this.Controls.Add(this.l_Number);
			this.Controls.Add(this.l_ID);
			this.Controls.Add(this.tbName);
			this.Controls.Add(this.tbID);
			this.Controls.Add(this.tbNumber);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CathegoryDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Категория тестов";
			this.Controls.SetChildIndex(this.tbNumber, 0);
			this.Controls.SetChildIndex(this.tbID, 0);
			this.Controls.SetChildIndex(this.tbName, 0);
			this.Controls.SetChildIndex(this.l_ID, 0);
			this.Controls.SetChildIndex(this.l_Number, 0);
			this.Controls.SetChildIndex(this.l_Name, 0);
			this.Controls.SetChildIndex(this.pnBottom, 0);
			this.ResumeLayout(false);

		}
		#endregion


		protected override void DataBind() {
			base.DataBind();

			if (IsNewItem) {
				this.Text += ": *";
				return;
			} 
			// получаем инфу
			int _ID = (int)PrimaryKey;
			CathegoryFacade facade = new CathegoryFacade();
			CathegoryInfo item = facade.GetCathegoryInfo(_ID);
			tbID.Text      = item.CathegoryID.ToString();
			tbNumber.Text  = item.Number.ToString();
			tbName.Text    = item.Name.ToString();
			this.Text += ": " + item.Name;
		}

		protected override void btnOK_Click(object sender, System.EventArgs e) {
			CathegoryFacade facade = new CathegoryFacade();
			CathegoryInfo item = new CathegoryInfo();
			item.Name = tbName.Text.Trim();

			if (IsNewItem) {
				int _ID = 0;
				item.Number = 1;
				facade.Add(item, out _ID);
			} else {
				item.Number = Int32.Parse(tbNumber.Text); 
				item.CathegoryID = (int)PrimaryKey;
				facade.Update(item);
			}

			Close();
		}


	}
}


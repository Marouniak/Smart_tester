using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace RtF.WinUtils.Grids
{
	/// <summary>
	/// Summary description for DateTimeDialog.
	/// </summary>
	public class DateTimeDialog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DateTimeDialog()
		{
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
		protected override void Dispose( bool disposing )
		{
			/*
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
			*/
		}

		public void Free()
		{
			if(components != null)
			{
				components.Dispose();
			}
			base.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Enter Date";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePicker1.Location = new System.Drawing.Point(9, 24);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(224, 20);
			this.dateTimePicker1.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(91, 56);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "OK";
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Location = new System.Drawing.Point(163, 56);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(64, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Cancel";
			// 
			// DateTimeDialog
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(242, 87);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button1,
																		  this.dateTimePicker1,
																		  this.label1,
																		  this.button2});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DateTimeDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Input Search Value";
			this.ResumeLayout(false);

		}
		#endregion

		public DateTime SelectedDateTime
		{
			get { return this.dateTimePicker1.Value; }
			set { this.dateTimePicker1.Value = value; }
		}

		public static DialogResult ShowDateTimeDialog(ref DateTime datetime)
		{
			DateTimeDialog dtDialog = new DateTimeDialog();
			dtDialog.SelectedDateTime = datetime;
			DialogResult dgResult = dtDialog.ShowDialog();
			datetime = dtDialog.SelectedDateTime;
			dtDialog.Free();

            return (dgResult);
		}
	}
}

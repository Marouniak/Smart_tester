using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace SmartZuSoft.SmartTester.WinApp {
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form {
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.TreeView tvTree;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.StatusBar sbBottom;
		private System.Windows.Forms.MenuItem menuItem2;
		private MenuExtender.MenuExtender menuExtender;
		private System.ComponentModel.IContainer components;

		public frmMain() {
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
				if (components != null) {
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.sbBottom = new System.Windows.Forms.StatusBar();
			this.tvTree = new System.Windows.Forms.TreeView();
			this.menuExtender = new MenuExtender.MenuExtender(this.components);
			this.SuspendLayout();
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2});
			this.menuItem1.Text = "Файл ";
			// 
			// menuItem2
			// 
			this.menuExtender.SetImageIndex(this.menuItem2, -1);
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "Go";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// sbBottom
			// 
			this.sbBottom.Location = new System.Drawing.Point(0, 275);
			this.sbBottom.Name = "sbBottom";
			this.sbBottom.Size = new System.Drawing.Size(544, 22);
			this.sbBottom.TabIndex = 1;
			// 
			// tvTree
			// 
			this.tvTree.Dock = System.Windows.Forms.DockStyle.Left;
			this.tvTree.ImageIndex = -1;
			this.tvTree.Location = new System.Drawing.Point(0, 0);
			this.tvTree.Name = "tvTree";
			this.tvTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																			   new System.Windows.Forms.TreeNode("Тесты"),
																			   new System.Windows.Forms.TreeNode("Пользователи"),
																			   new System.Windows.Forms.TreeNode("Категории")});
			this.tvTree.SelectedImageIndex = -1;
			this.tvTree.Size = new System.Drawing.Size(121, 275);
			this.tvTree.TabIndex = 2;
			this.tvTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTree_AfterSelect);
			// 
			// menuExtender
			// 
			this.menuExtender.Font = null;
			this.menuExtender.SystemFont = true;
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(544, 297);
			this.Controls.Add(this.tvTree);
			this.Controls.Add(this.sbBottom);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.Menu = this.mainMenu;
			this.Name = "frmMain";
			this.Text = "Smart Tester";
			this.MdiChildActivate += new System.EventHandler(this.frmMain_MdiChildActivate);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.Run(new frmMain());
		}

		public void SelectForm(Form child) {	
			for(int i = 0; i <= this.MdiChildren.Length - 1; i++) {
				if (this.MdiChildren.GetValue(i) == child) {
					child.Activate();
					return ;
				}
			}
			//child.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			child.MdiParent = this;
			child.Show();
			child.Dock = System.Windows.Forms.DockStyle.Fill;
		}


		private void tvTree_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e) {
			//string action = ((string)tvTree.SelectedNode.Tag).Trim(); 
			string action = tvTree.SelectedNode.Text.Trim(); 
			switch(action) {
				case "Категории":
					CathegoryList list = CathegoryList.GetInstance();
					SelectForm(list);
					break;
				default:
					break;
			}

		}

		private void frmMain_MdiChildActivate(object sender, System.EventArgs e) {
			string caption = String.Empty;
			if (ActiveMdiChild != null) {
				caption = ActiveMdiChild.Text;
			}
			sbBottom.Text = caption;
		}

		private void menuItem2_Click(object sender, System.EventArgs e) {
			Test1 frm = new Test1();
			frm.ShowDialog();
		}
	}
}

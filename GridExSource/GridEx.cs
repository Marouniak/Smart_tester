using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace RtF.WinUtils.Grids
{

	/// <summary>
	/// DataGridHeaderEventArgs class
	/// </summary>
	public class DataGridHeaderEventArgs: EventArgs
	{
		private int _column = -1;
		private int _row = -1;

		public DataGridHeaderEventArgs(int col, int row)
		{
			_column = col;
			_row = row;
		}

		public override string ToString()
		{
			return String.Format("Column = {0}, Row = {1}", _column, _row);
		}

		public int Column
		{
			get { return _column; }
		}

		public int Row
		{
			get { return _row; }
		}
	}

	// declare delegate
	public delegate void HeaderEventHandler(DataGridHeaderEventArgs e);


	/// <summary>
	/// Summary description for GridEx.
	/// </summary>
	public class GridEx : System.Windows.Forms.DataGrid
	{
		// Events declaration
		public event EventHandler CurrentRowChanged;
		public event HeaderEventHandler HeaderClicked;

		// protected fields
		protected int LastRowIndex = 0;
		protected int LastStyleIndex = -1;
		protected DataGridTableStyle _defaultGridStyle = null;
		protected DataGridTableStyle storedGridStyle = new DataGridTableStyle();

		// private fields
		private int _selectedHeaderColumn = -1;
		private int _currentStyleIndex = -1;
		private bool _autoSize = true;
		private bool _autoSearch = false;
		private bool _rowSelect = true;
		private bool _useGridParentStyle = false;
		private string _searchText = "";

		public GridEx()
		{
			
			InitializeComponent();

			// register HeaderClick event
			this.HeaderClicked += new HeaderEventHandler( InternalHeaderClick );
		}

		private void InitializeComponent()
		{
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// GridEx
			// 
			this.ReadOnly = true;
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
		}

		#region Methods...

		protected void SetDefaultGridStyle()
		{
			SetGridStyle(-1);
			DoGridResize();
		}

		protected void SetGridStyle(int styleIndex)
		{
			if (this.CurrentView == null)
				return;

			ResetStyle(this.LastStyleIndex);
			// set current style
			if (this.UseGridParentStyle)
			{
				if (styleIndex == -1)
				{
					this.DefaultGridStyle.MappingName = this.CurrentView.Table.TableName;
				}
				else 
				{
					// save style
					CopyGridStyle(this.TableStyles[styleIndex], storedGridStyle);
					// set style
					this.SetParentStyle(this.TableStyles[styleIndex]);
					this.TableStyles[styleIndex].MappingName = this.CurrentView.Table.TableName;
				}
			}
			else
			{
				if (styleIndex == -1)
				{
					this.DefaultGridStyle.MappingName = this.CurrentView.Table.TableName;
				}
				else 
				{
					// save style
					CopyGridStyle(this.TableStyles[styleIndex], storedGridStyle);
					// set style
					this.TableStyles[styleIndex].MappingName = this.CurrentView.Table.TableName;
				}
			}

			this.LastStyleIndex = styleIndex;
		}

		protected void ResetStyle(int styleIndex)
		{
			if (styleIndex == -1)
			{
				this.DefaultGridStyle.MappingName = "";
			}
			else
			{
				CopyGridStyle(storedGridStyle, this.TableStyles[styleIndex]);
				this.TableStyles[this.LastStyleIndex].MappingName = "";
			}
		}

		protected void DoGridResize()
		{
			if (this.CurrentView != null)
			{
				if (this.AutoSize)
					AutoSizeGrid();
				else
					ResetAutoSizeGrid();
			}
		}

		protected virtual void CopyGridStyle(DataGridTableStyle source, DataGridTableStyle target)
		{
			// copy style from datagrid
			target.GridLineStyle = source.GridLineStyle;
			target.HeaderFont = source.HeaderFont;
			target.AllowSorting = source.AllowSorting;
			target.AlternatingBackColor = source.AlternatingBackColor;
			target.BackColor = source.BackColor;
			target.ForeColor = source.ForeColor;
			target.GridLineColor = source.GridLineColor;
			target.HeaderBackColor = source.HeaderBackColor;
			target.HeaderForeColor = source.HeaderForeColor;
			target.LinkColor = source.LinkColor;
			target.SelectionBackColor = source.SelectionBackColor;
			target.SelectionForeColor = source.SelectionForeColor;
			target.ColumnHeadersVisible = source.ColumnHeadersVisible;
			target.RowHeadersVisible = source.RowHeadersVisible;
			target.PreferredColumnWidth = source.PreferredColumnWidth;
			target.PreferredRowHeight = source.PreferredRowHeight;
		}

		protected virtual void SetParentStyle(DataGridTableStyle gridStyle)
		{
            // copy style from datagrid
			gridStyle.GridLineStyle = this.GridLineStyle;
			gridStyle.HeaderFont = this.HeaderFont;
			gridStyle.AllowSorting = this.AllowSorting;
			gridStyle.AlternatingBackColor = this.AlternatingBackColor;
			gridStyle.BackColor = this.BackColor;
			gridStyle.ForeColor = this.ForeColor;
			gridStyle.GridLineColor = this.GridLineColor;
			gridStyle.HeaderBackColor = this.HeaderBackColor;
			gridStyle.HeaderForeColor = this.HeaderForeColor;
			gridStyle.LinkColor = this.LinkColor;
			gridStyle.SelectionBackColor = this.SelectionBackColor;
			gridStyle.SelectionForeColor = this.SelectionForeColor;
			gridStyle.ColumnHeadersVisible = this.ColumnHeadersVisible;
			gridStyle.RowHeadersVisible = this.RowHeadersVisible;
			gridStyle.PreferredColumnWidth = this.PreferredColumnWidth;
			gridStyle.PreferredRowHeight = this.PreferredRowHeight;
		}

		protected bool IsSearchMode()
		{
			return ((this.AutoSearch) && (this.SelectedHeaderColumn > -1));
		}

		protected void DisplaySearchText()
		{
			if (this.SearchText.Length ==0)
				this.CaptionText = "";
			else
				this.CaptionText = String.Format("[{0}] = '{1}'",
					this.SelectedHeaderField, this.SearchText);
		}

		protected virtual void Search(string searchText)
		{
			DataView dataView = this.CurrentView;
			if (dataView != null)
			{
				string filterExpr = "";
				if (searchText != "")
					filterExpr = String.Format(GenerateFilterExpression(), searchText);
				DisplaySearchText();
                dataView.RowFilter = filterExpr;
			}
		}

		protected string GenerateFilterExpression()
		{
			DataTable dt = this.CurrentView.Table;
			string expr = "";

			//MessageBox.Show(dt.Columns[this.SelectedHeaderField].DataType.ToString());
			switch(dt.Columns[this.SelectedHeaderField].DataType.ToString())
			{
				case "System.String":
					expr = String.Format("{0} Like {1}", this.SelectedHeaderField, "'{0}%'");
					break;
				case "System.Byte":
				case "System.Decimal":
				case "System.Double":
				case "System.Int16":
				case "System.Int32":
				case "System.Int64":
					expr = String.Format("{0} >= {1}", this.SelectedHeaderField, "{0}");
					break;
				case "System.DateTime":
					expr = String.Format("{0} >= {1}", this.SelectedHeaderField, "#{0}#");
					break;
			}
            return (expr);
		}

		protected bool IsValidChar(Char c)
		{
			bool validChar = false; 

			switch(this.SelectedHeaderFieldType.ToString())
			{
				case "System.String":
					validChar = Char.IsLetterOrDigit(c);
					break;
				case "System.Byte":
				case "System.Decimal":
				case "System.Double":
				case "System.Int16":
				case "System.Int32":
				case "System.Int64":
					validChar = Char.IsDigit(c);
					break;
			}
			return (validChar);
		}

		protected void AutoSizeGrid()
		{
			DataGridTableStyle dgStyle = GetCurrentStyle();
			int numCols = dgStyle.GridColumnStyles.Count;
			for (int i = 0; i < numCols; ++i)
				AutoSizeColumn(i);
		}

		protected void ResetAutoSizeGrid()
		{
			DataGridTableStyle dgStyle = GetCurrentStyle();
			int numCols = dgStyle.GridColumnStyles.Count;
			for (int i = 0; i < numCols; ++i)
				dgStyle.GridColumnStyles[i].Width = this.PreferredColumnWidth;
		}

		protected void AutoSizeColumn(int col)
		{
			DataGridTableStyle dgStyle = GetCurrentStyle();
			float width = 0;
			int numRows = this.CurrentView.Count;

			Graphics g = Graphics.FromHwnd(this.Handle);
			StringFormat sf = new StringFormat(StringFormat.GenericTypographic);

			int paddingFactorData = 15;
			int paddingFactorHeader = 15;

			SizeF headerSize;
			headerSize = g.MeasureString(dgStyle.GridColumnStyles[col].HeaderText, this.Font, 500, sf);

			SizeF size;
			for(int i=0; i < numRows; ++i)
			{
				size = g.MeasureString(this[i, col].ToString(), this.Font, 500, sf);

				if (size.Width > width)
					width = size.Width;
			}
			g.Dispose();
			if (headerSize.Width < width)
				dgStyle.GridColumnStyles[col].Width = (int)width + paddingFactorData;
			else
				dgStyle.GridColumnStyles[col].Width = (int)headerSize.Width + paddingFactorHeader;   
		}

		protected DataGridTableStyle GetCurrentStyle()
		{
			DataGridTableStyle dgs = this.TableStyles[this.CurrentView.Table.TableName];
			return (dgs);
		}

		#endregion

		#region Event Methods...

		protected virtual void OnHeaderClick(DataGridHeaderEventArgs e)
		{
			if (HeaderClicked != null)
				HeaderClicked(e);
		}

		protected void OnCurrentRowChanged(object sender, EventArgs e)
		{
			if (this.CurrentRowChanged != null)
				this.CurrentRowChanged(sender, e);
		}

		protected void InternalHeaderClick(DataGridHeaderEventArgs e)
		{
			if (_selectedHeaderColumn != e.Column)
			{
				_selectedHeaderColumn = e.Column;
				this._searchText = "";
				GenerateFilterExpression();
			}
			// this allows datagrid accept KeyPress event
			this.CurrentCell = new DataGridCell(-1,-1);
		}

		#endregion

		#region Override Event Methods...

		protected override void OnDataSourceChanged(EventArgs e)
		{
			if ((!this.DesignMode) && (!this.TableStyles.Contains(this.DefaultGridStyle)))
				this.TableStyles.Add(this.DefaultGridStyle);

			if ((GetCurrentStyle() == null) && (!this.DesignMode))
				SetDefaultGridStyle();

			if ((this.AutoSize) && (this.CurrentView != null))
				AutoSizeGrid();

			base.OnDataSourceChanged(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			HitTestInfo hi = this.HitTest(e.X, e.Y);
			if ((hi.Row == -1) && (hi.Column > -1))
				OnHeaderClick(new DataGridHeaderEventArgs(hi.Column, hi.Row));
                
			base.OnMouseUp(e);
		}

		protected override void OnVisibleChanged(EventArgs e)
		{
			if ((this.RowSelect) && (this.CurrentRowIndex > -1))
				this.Select(this.CurrentRowIndex);

			base.OnVisibleChanged(e);
		}

		protected override void OnCurrentCellChanged(EventArgs e)
		{
			if (this.RowSelect)
				this.Select(this.CurrentRowIndex);

			if (this.LastRowIndex != this.CurrentRowIndex)
			{
				this.LastRowIndex = this.CurrentRowIndex;
				// raises RowChanged event
				OnCurrentRowChanged(null, e);
			}

			base.OnCurrentCellChanged(e);
		}

		protected override void OnKeyPress(KeyPressEventArgs kpe)
		{
			if (IsSearchMode())
			{
				if (Char.IsLetterOrDigit(kpe.KeyChar))
				{
					// Handle datetime search
					if (this.SelectedHeaderFieldType == typeof(DateTime))
					{
						DateTime dt = DateTime.Today; 
						if (DateTimeDialog.ShowDateTimeDialog(ref dt)==DialogResult.OK)
							this.SearchText = dt.ToString("M/d/yyyy");
					}
					else if (IsValidChar(kpe.KeyChar))
                        this.SearchText += kpe.KeyChar;
				}
				else 
				{
					switch(Convert.ToByte(kpe.KeyChar))
					{
						// [Backspace] key
						case 8:
							if (this.SearchText.Length > 0)
							{
								if (this.SelectedHeaderFieldType == typeof(DateTime))
									this.SearchText = "";
								else
									this.SearchText = this.SearchText.Substring(0,this.SearchText.Length-1);
							}
							break;
						// [Escape] key
						case 27:
							this.SearchText = "";
							break;
					}
				}
			}

			base.OnKeyPress(kpe);
		}

		#endregion

		#region Protected Properties...

		protected DataView CurrentView
		{
			get 
			{
				DataView dv = null;
				if ((this.DataSource is DataSet) && (this.DataMember.Length > 0))
				{
					// Turn off AutoSearch if DataSource is DataSet
					this.AutoSearch = false;
					dv = ((DataSet)this.DataSource).Tables[this.DataMember].DefaultView;
				}
				else if (this.DataSource is DataTable)
					dv = ((DataTable)this.DataSource).DefaultView;
				else if (this.DataSource is DataView)
					dv = (DataView)this.DataSource;

				return dv;
			}
		}

		protected string SearchText
		{
			get { return _searchText; }
			set 
			{
				_searchText = value;
				if (IsSearchMode())
					Search(_searchText);
			}
		}

		protected DataGridTableStyle DefaultGridStyle
		{
			get 
			{
				if (this._defaultGridStyle == null)
				{
					this._defaultGridStyle = new DataGridTableStyle();
					SetParentStyle(_defaultGridStyle);
				}


				//if (this.CurrentView != null)
				//	this._defaultGridStyle.MappingName = this.CurrentView.Table.TableName;

				return _defaultGridStyle;
			}
		}

		protected int SelectedHeaderColumn
		{
			get { return _selectedHeaderColumn; }
		}

		protected string SelectedHeaderField
		{
			get 
			{ 
				return this.TableStyles[this.CurrentView.Table.TableName].GridColumnStyles[this.SelectedHeaderColumn].MappingName; 
			}
		}

		protected Type SelectedHeaderFieldType
		{
			get 
			{ 
				return this.CurrentView.Table.Columns[this.SelectedHeaderField].DataType;
			}
		}
		#endregion

		#region Public Properties...

		public bool AutoSize
		{
			get 
			{ 
				return _autoSize; 
			}
			set 
			{ 
				if (_autoSize != value)
				{
					_autoSize = value;
					if (!this.DesignMode) 
						DoGridResize();
				}
			}
		}

		public bool AutoSearch
		{
			get { return _autoSearch; }
			set { _autoSearch = value; }
		}
		
		public bool RowSelect
		{
			get { return _rowSelect; }
			set { _rowSelect = value; }
		}

		public bool UseGridParentStyle
		{
			get { return _useGridParentStyle; }
			set 
			{ 
				if (_useGridParentStyle != value)
				{
					_useGridParentStyle = value; 
					SetGridStyle(this.CurrentStyleIndex);
				}
			}
		}

		public int CurrentStyleIndex
		{
			get { return _currentStyleIndex; }
			set 
			{
				if (!((value >= -1) && (value < this.TableStyles.Count)))
					throw new Exception(String.Format("Valid value [-1] to [{0}]", this.TableStyles.Count-1));

				if (_currentStyleIndex != value)
				{
					_currentStyleIndex = value;
					SetGridStyle(_currentStyleIndex);
					DoGridResize();
				}
			}
		}

		#endregion
	}
}

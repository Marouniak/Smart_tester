using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;

using SmartZuSoft.SmartTester.Common;
using FirebirdSql.Data.Firebird;


namespace SmartZuSoft.SmartTester.DAL {
	/// <summary>
	/// CathegoryDAL.
	/// </summary>
	public class CathegoryDAL :System.ComponentModel.Component {
		private System.ComponentModel.Container components = null;

		#region Constants
		private const string CathegoryID     = "@CATHEGORY_ID";
		private const string CathegoryNumber = "@NUMBER";
		private const string CathegoryName   = "@NAME";
		#endregion

		#region private members
		private FbCommand loadCathegoriesCmd;
		private FbCommand loadCathegoryInfoCmd;
		private FbCommand addCathegoryCmd;
		private FbCommand updateCathegoryInfoCmd;
		private FbCommand deleteCathegoryCmd;
		private FbCommand genNewIDCmd;
		#endregion

		#region Constructors
		public CathegoryDAL(System.ComponentModel.IContainer container) {
			container.Add(this);
			InitializeComponent();
		}

		public CathegoryDAL() {
			InitializeComponent();
		}
		#endregion

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			components = new System.ComponentModel.Container();
		}
		#endregion
		
		#region destructors
		/// <summary>
		///     Dispose of this object's resources.
		/// </summary>
		public new void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(true); // as a service to those who might inherit from us
		}


		/// <summary>
		///		Free the instance variables of this object.
		/// </summary>
		protected new virtual void Dispose(bool disposing) {
			if (! disposing)
				return; // we're being collected, so let the GC take care of this object
			try {
				if(loadCathegoriesCmd != null)
					loadCathegoriesCmd.Dispose();
				if(loadCathegoryInfoCmd != null)
					loadCathegoryInfoCmd.Dispose();
				if(addCathegoryCmd != null)
					addCathegoryCmd.Dispose();
				if(updateCathegoryInfoCmd != null)
					updateCathegoryInfoCmd.Dispose();
				if(deleteCathegoryCmd != null)
					deleteCathegoryCmd.Dispose();
				if(genNewIDCmd != null)
					genNewIDCmd.Dispose();
			} finally {
				base.Dispose(disposing);
			}
		}
        
		#endregion

		#region SQL Command Getters
		private FbCommand GetLoadCathegoriesCommand(FilterExpression filter, OrderExpression order) {
			if (loadCathegoriesCmd == null) {
				string cmdText = "SELECT * FROM CATHEGORY";
				if(filter != null)
					if(filter.ToString().Trim() != String.Empty)
						cmdText += " WHERE "+filter.ToString();
				if(order != null)
					if(order.ToString().Trim() != String.Empty)
						cmdText += " ORDER BY "+order.ToString();
				loadCathegoriesCmd = new FbCommand(cmdText);
				loadCathegoriesCmd.CommandType = CommandType.Text;
			}
			return loadCathegoriesCmd;
		}


		private FbCommand GetLoadCathegoryInfoCommand(int cathegoryID) {
			if (loadCathegoryInfoCmd == null) {
				string cmdText = "SELECT * FROM CATHEGORY";
				cmdText += " WHERE CATHEGORY_ID="+cathegoryID.ToString();
				loadCathegoryInfoCmd = new FbCommand(cmdText);
				loadCathegoryInfoCmd.CommandType = CommandType.Text;
			}
			return loadCathegoryInfoCmd;
		}


		private FbCommand GetAddCathegoryCommand() {
			if(addCathegoryCmd == null) {
				string cmdText = "INSERT INTO CATHEGORY(CATHEGORY_ID, NUMBER,NAME)";
				cmdText += " VALUES(@CATHEGORY_ID, @Number,@Name)";
				addCathegoryCmd = new FbCommand(cmdText);
				addCathegoryCmd.CommandType = CommandType.Text;

				addCathegoryCmd.Parameters.Add(CathegoryID, FbDbType.Integer);
				addCathegoryCmd.Parameters.Add(CathegoryNumber, FbDbType.Integer);
				addCathegoryCmd.Parameters.Add(CathegoryName, FbDbType.VarChar);
			}
			return addCathegoryCmd;
		}


		private FbCommand GetUpdateCathegoryCommand() {
			if(updateCathegoryInfoCmd == null) {
				string cmdText = "UPDATE CATHEGORY";
				cmdText += " SET Number=@NUMBER,Name=@NAME";
				cmdText += " WHERE (CATHEGORY_ID=@CATHEGORY_ID)";
				updateCathegoryInfoCmd = new FbCommand(cmdText);
				updateCathegoryInfoCmd.CommandType = CommandType.Text;

				updateCathegoryInfoCmd.Parameters.Add(CathegoryID, FbDbType.Integer);
				updateCathegoryInfoCmd.Parameters.Add(CathegoryNumber, FbDbType.Integer);
				updateCathegoryInfoCmd.Parameters.Add(CathegoryName, FbDbType.VarChar);
			}
			return updateCathegoryInfoCmd;
		}


		private FbCommand GetDeleteCathegoryCommand(int cathegoryID) {
			if (deleteCathegoryCmd == null) {
				string cmdText = "DELETE FROM CATHEGORY";
				cmdText += " WHERE CATHEGORY_ID="+cathegoryID.ToString();
				deleteCathegoryCmd = new FbCommand(cmdText);
				deleteCathegoryCmd.CommandType = CommandType.Text;
			}
			return deleteCathegoryCmd;
		}

		
		private FbCommand GetGenNewIDCommand() {
			if (genNewIDCmd == null) {
				string cmdText = "SELECT GEN_ID(GEN_CATHEGORY_ID,1) AS NEWID FROM RDB$DATABASE";
				genNewIDCmd = new FbCommand(cmdText);
				genNewIDCmd.CommandType = CommandType.Text;
			}
			return genNewIDCmd;
		}


	
		#endregion

		#region public commands
		public CathegoryInfo[] GetCathegories(FilterExpression filter, OrderExpression order) {
			FbCommand cmd = GetLoadCathegoriesCommand(filter, order);

			CathegoryInfo[] cathegories = null;
			ArrayList elements = new ArrayList();
			FbConnection conn = null;
			FbTransaction trans = null;
			try {
				conn = new FbConnection(DBFactory.ConnectionString());
				conn.Open();
				trans = conn.BeginTransaction();
				cmd.Connection = conn;
				cmd.Transaction = trans;
				FbDataReader reader = cmd.ExecuteReader();
				while (reader.Read()) {
					CathegoryInfo ci = new CathegoryInfo();
					ci.CathegoryID = (int)reader["CATHEGORY_ID"];
					if (reader["Name"] != DBNull.Value)
						ci.Name = (string)reader["Name"]; 
					if (reader["Number"] != DBNull.Value)
						ci.Number = (int)reader["Number"]; 
					elements.Add(ci);
				}
				reader.Close();
				trans.Commit();
				if (elements.Count != 0) {
					cathegories = new CathegoryInfo[elements.Count];
					elements.CopyTo(cathegories);
				}
			} catch (Exception ex) {
				//return null;
				trans.Rollback();
				throw new Exception(ex.Message);
			} finally {
				cmd.Connection = null;
				if (conn != null) {
					conn.Close();
					conn.Dispose();
				}
			}
			return cathegories;
		}


		public CathegoryInfo GetCathegoryInfo(int cathegoryID) {
			FbCommand cmd = GetLoadCathegoryInfoCommand(cathegoryID);

			CathegoryInfo item = null;
			FbConnection conn = null;
			FbTransaction trans = null;
			try {
				conn = new FbConnection(DBFactory.ConnectionString());
				cmd.Connection = conn;
				conn.Open();
				trans = conn.BeginTransaction();
				cmd.Connection = conn;
				cmd.Transaction = trans;
				FbDataReader reader = cmd.ExecuteReader();
				if (reader.Read()) {
					item = new CathegoryInfo();
					item.CathegoryID = (int)reader["CATHEGORY_ID"];
					if (reader["Name"] != DBNull.Value)
						item.Name = (string)reader["Name"]; 
					if (reader["Number"] != DBNull.Value)
						item.Number = (int)reader["Number"]; 
				}
				reader.Close();
				trans.Commit();
			} catch {
				trans.Rollback();
				return null;
			} finally {
				cmd.Connection = null;
				if (conn != null) {
					conn.Close();
					conn.Dispose();
				}
			}
			return item;
		}

		
		public bool AddCathegory(CathegoryInfo item, out int cathegoryID) {
			FbCommand cmd = GetAddCathegoryCommand();
			
			int rowsAffected = 0;
			cathegoryID = PersistentBusinessEntity.ID_Empty;
			FbConnection conn = null;
			FbTransaction trans = null;
			try {
				conn = new FbConnection(DBFactory.ConnectionString());
				conn.Open();
				trans = conn.BeginTransaction();
				cmd.Connection = conn;
				cathegoryID = GenNewID(conn, trans);
				cmd.Parameters[CathegoryID].Value = cathegoryID;
				cmd.Parameters[CathegoryNumber].Value  = (Object)item.Number;   
				cmd.Parameters[CathegoryName].Value = (item.Name == null) ? DBNull.Value : (Object)item.Name;
				cmd.Connection = conn;
				cmd.Transaction = trans;
				rowsAffected = cmd.ExecuteNonQuery();
				trans.Commit();
			} catch (Exception ex) {
				trans.Rollback();
				throw new Exception(ex.Message);
			} finally {
				cmd.Connection = null;
				if (conn != null) {
					conn.Close();
					conn.Dispose();
				}
			}
			return true;
		}


		public bool UpdateCathegoryInfo(CathegoryInfo item) {
			FbCommand cmd = GetUpdateCathegoryCommand();
			cmd.Parameters[CathegoryID].Value  = item.CathegoryID;   
			if (item.Name == null) {
				cmd.Parameters[CathegoryName].Value =  DBNull.Value;
			} else {
				cmd.Parameters[CathegoryName].Value =  item.Name;
			}
			cmd.Parameters[CathegoryNumber].Value  = item.Number;   

			int rowsAffected = 0;
			FbConnection conn = null;
			FbTransaction trans = null;
			try {
				conn = new FbConnection(DBFactory.ConnectionString());
				cmd.Connection = conn;
				conn.Open();
				trans = conn.BeginTransaction();
				cmd.Connection = conn;
				cmd.Transaction = trans;
				rowsAffected = cmd.ExecuteNonQuery();
				trans.Commit();
			} catch (Exception ex) {
				trans.Rollback();
				throw new Exception(ex.Message);
				//return false;
			} finally {
				cmd.Connection = null;
				if (conn != null) {
					conn.Close();
					conn.Dispose();
				}
			}
			return true;
		}


		public bool DeleteCathegory(int cathegoryID) {
			FbCommand cmd = GetDeleteCathegoryCommand(cathegoryID);
			
			int rowsAffected = 0;
			FbConnection conn = null;
			FbTransaction trans = null;
			try {
				conn = new FbConnection(DBFactory.ConnectionString());
				cmd.Connection = conn;
				conn.Open();
				trans = conn.BeginTransaction();
				cmd.Connection = conn;
				cmd.Transaction = trans;
				rowsAffected = cmd.ExecuteNonQuery();
				trans.Commit();
			} catch (Exception ex) {
				trans.Rollback();
				throw new Exception(ex.Message);
				//return false;
			} finally {
				cmd.Connection = null;
				if (conn != null) {
					conn.Close();
					conn.Dispose();
				}
			}
			return true;
		}


		private int GenNewID(FbConnection conn ,FbTransaction trans) {
			FbCommand cmd = GetGenNewIDCommand();

			int newID = PersistentBusinessEntity.ID_Empty;
			try {
				cmd.Connection = conn;
				cmd.Transaction = trans;
				object result = cmd.ExecuteScalar();
				newID = (int)Convert.ChangeType(result, typeof(Int32));
			} catch {
				return PersistentBusinessEntity.ID_Empty;
			}
			return newID;
		}

		


		#endregion

	}
}
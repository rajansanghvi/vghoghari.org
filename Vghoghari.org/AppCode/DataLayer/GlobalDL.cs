using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using Vghoghari.org.AppCode.Models;
using Vghoghari.org.AppCode.Utilities;

namespace Vghoghari.org.AppCode.DataLayer {
	internal class GlobalDL {
		private static readonly string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString();
		private List<KeyValuePair<string, object>> parameterCollection;
		private MySqlConnection sqlConnection;

		public GlobalDL() {
			parameterCollection = new List<KeyValuePair<string, object>>();
		}

		internal void AddParameter(string parameterName, object parameterValue) {
			parameterCollection.Add(new KeyValuePair<string, object>(parameterName, parameterValue));
		}

		internal void AddDateParameter(string parameterName, DateTime? parameterValue) {
			DateTime value = (parameterValue == null) ? DateTime.MinValue : parameterValue.Value;

			parameterCollection.Add(new KeyValuePair<string, object>(parameterName, DateUtility.GetDateForSqlParam(value)));
		}

		internal void AddDateParameterWithNull(string parameterName, DateTime? parameterValue) {
			if (parameterValue == null) {
				parameterCollection.Add(new KeyValuePair<string, object>(parameterName, DBNull.Value));
			}
			else {
				parameterCollection.Add(new KeyValuePair<string, object>(parameterName, DateUtility.GetDateForSqlParam(parameterValue.Value)));
			}
		}

		internal void AddIntParameter(string parameterName, object parameterValue) {
			if (parameterValue == null || String.IsNullOrWhiteSpace(parameterValue.ToString())) {
				parameterValue = DBNull.Value;
			}

			AddParameter(parameterName, parameterValue);
		}

		internal void AddLikeParameter(string parameterName, string parameterValue) {
			parameterCollection.Add(new KeyValuePair<string, object>(parameterName, Utility.AddWildCard(parameterValue)));
		}

		internal void ClearParams() {
			parameterCollection.Clear();
		}

		internal object ExecuteSqlReturnScalar(string connectionString, string sql) {
			const string methodName = "ExecuteSqlReturnScalar";
			
			try {
				using (sqlConnection = new MySqlConnection(connectionString)) {
					using (MySqlCommand command = sqlConnection.CreateCommand()) {
						command.CommandType = CommandType.Text;
						command.CommandText = sql;
						sqlConnection.Open();

						foreach (KeyValuePair<string, object> item in parameterCollection) {
							command.Parameters.AddWithValue(item.Key, item.Value);
						}

						return command.ExecuteScalar();
					}
				}
			}
			catch (Exception ex) {
				sqlConnection.Close();
				//TODO: Log Exception
				throw ex;
			}
			finally {
				ClearParams();
			}
		}
		
		internal T ExecuteSqlReturnScalar<T>(string connectionString, string sql) {
			const string methodName = "ExecuteSqlReturnScalar<T>";
			object val = ExecuteSqlReturnScalar(connectionString, sql);

			try {
				if (val == null || val == DBNull.Value) {
					return default(T);
				}
				else {
					return (T) Convert.ChangeType(val, typeof(T));
				}
			}
			catch (InvalidCastException ex) {
				// log exception
				throw ex;
			}
			catch(FormatException ex) {
				//log exception
				throw ex;
			}
			catch(OverflowException ex) {
				// log exception
				throw ex;
			}
			catch(ArgumentNullException ex) {
				// log exception
				throw ex;
			}
		}
		
		internal MySqlDataReader ExecuteSqlReturnReader(string connectionString, string sql) {
			const string methodName = "ExecuteSqlReturnReader";
			sqlConnection = new MySqlConnection(connectionString);

			try {
				using (MySqlCommand command = sqlConnection.CreateCommand()) {
					command.CommandType = CommandType.Text;
					command.CommandText = sql;

					foreach (KeyValuePair<string, object> item in parameterCollection) {
						command.Parameters.AddWithValue(item.Key, item.Value);
					}

					sqlConnection.Open();

					return command.ExecuteReader(CommandBehavior.CloseConnection);
				}
			}
			catch (Exception ex) {
				sqlConnection.Close();
				//TODO: log exception
				throw ex;
			}
			finally {
				ClearParams();
			}
		}

		internal void ExecuteProcedureNonQuery(string connectionString, string procedureName) {
			const string methodName = "ExecuteProcedureNonQuery";
			try {
				using (sqlConnection = new MySqlConnection(connectionString)) {
					using (MySqlCommand command = sqlConnection.CreateCommand()) {
						command.CommandType = CommandType.StoredProcedure;
						command.CommandText = procedureName;

						foreach (KeyValuePair<string, object> item in parameterCollection) {
							command.Parameters.AddWithValue(item.Key, item.Value);
						}

						sqlConnection.Open();

						command.ExecuteNonQuery();
					}
				}
			}
			catch (Exception ex) {
				// log exception
				throw ex;
			}
			finally {
				ClearParams();
			}
		}

		private void HandleCallback(IAsyncResult result) {
			const string methodName = "HandleCallback";

			try {
				// Retrieve the original command object, passed
				// to this procedure in the AsyncState property
				// of the IAsyncResult parameter.
				MySqlCommand command = (MySqlCommand) result.AsyncState;
				try {
					command.EndExecuteNonQuery(result);
				}
				catch(Exception innerEx) {
					//log exception
				}
			}
			catch (Exception ex) {
				// log exception
			}
			finally {
				if (sqlConnection != null) {
					sqlConnection.Close();
				}
			}
		}

		internal void ExecuteProcedureNonQueryAsync(string connectionString, string procedureName) {
			const string methodName = "ExecuteProcedureNonQueryAsync";			
			try {
				sqlConnection = new MySqlConnection(connectionString);

				MySqlCommand command = sqlConnection.CreateCommand();
				command.CommandType = CommandType.StoredProcedure;
				command.CommandText = procedureName;

				foreach (KeyValuePair<string, object> item in parameterCollection) {
					command.Parameters.AddWithValue(item.Key, item.Value);
				}

				sqlConnection.Open();

				command.BeginExecuteNonQuery(new AsyncCallback(HandleCallback), command);
			}
			catch (Exception ex) {
				// log exception
				throw ex;
			}
			finally {
				ClearParams();
			}
		}

		internal MySqlDataReader ExecuteProcedureReturnReader(string connString, string proc) {
			const string methodName = "ExecuteProcedureReturnReader";
			sqlConnection = new MySqlConnection(connString);

			try {
				using (MySqlCommand cmd = sqlConnection.CreateCommand()) {
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = proc;

					foreach (KeyValuePair<string, object> item in this.parameterCollection) {
						cmd.Parameters.AddWithValue(item.Key, item.Value);
					}

					sqlConnection.Open();

					return cmd.ExecuteReader(CommandBehavior.CloseConnection);
				}
			}
			catch (Exception ex) {
				sqlConnection.Close();
				throw ex;
			}
			finally {
				ClearParams();
			}
		}

		internal object ExecuteProcedureReturnScalar(string connString, string proc) {
			const string methodName = "ExecuteProcedureReturnScalar";
			try {
				using (MySqlConnection conn = new MySqlConnection(connString)) {
					using (MySqlCommand cmd = conn.CreateCommand()) {
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.CommandText = proc;

						foreach (KeyValuePair<string, object> item in parameterCollection) {
							cmd.Parameters.AddWithValue(item.Key, item.Value);
						}

						conn.Open();

						return cmd.ExecuteScalar();
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			finally {
				ClearParams();
			}
		}

		internal T ExecuteProcedureReturnScalar<T>(string connString, string proc) {
			object val = this.ExecuteProcedureReturnScalar(connString, proc);

			if (val == null || val == DBNull.Value) {
				return default(T);
			}
			else {
				return (T) Convert.ChangeType(val, typeof(T));
			}
		}

		internal int ExecuteSqlNonQuery(string sql) {
			return this.ExecuteSqlNonQuery(Utility.ConnectionString, sql);
		}

		internal int ExecuteSqlNonQuery(string connString, string sql) {
			const string methodName = "ExecuteSqlNonQuery";
			int recordsAffected = 0;

			try {
				using (sqlConnection = new MySqlConnection(connString)) {
					using (MySqlCommand cmd = sqlConnection.CreateCommand()) {
						cmd.CommandType = CommandType.Text;
						cmd.CommandText = sql;

						sqlConnection.Open();

						foreach (KeyValuePair<string, object> item in parameterCollection) {
							cmd.Parameters.AddWithValue(item.Key, item.Value);
						}

						recordsAffected = cmd.ExecuteNonQuery();
					}
				}
			}
			catch (Exception ex) {
				throw ex;
			}
			finally {
				ClearParams();
			}
			return recordsAffected;
		}

		internal DateTime GetDbTime(string connStr) {
			const string methodName = "GetDbTime";

			const string sql = @"select current_timestamp();";

			DateTime returnValue = DateTime.Parse(ExecuteSqlReturnScalar(connStr, sql).ToString());
			return returnValue;
		}

		internal int GetIntWithDefault(object value) {
			int returnValue;

			if (Int32.TryParse(value.ToString(), out returnValue)) {
				return returnValue;
			}
			else {
				return 0;
			}
		}

		internal void GetResults(string sql, List<FilterDto> filters, List<KeyValuePair<string, string>> orderByCols, int pageSize, int pageNumber) {
			StringBuilder sb = new StringBuilder();
			int counter = 0;

			sb.AppendLine(sql);

			if (filters.Count > 0) {
				foreach (FilterDto f in filters) {
					if (counter == 0) {
						sb.AppendLine(" where ");
					}
					else {
						sb.AppendLine(" and ");
					}
					sb.AppendLine(f.ColumnName);
					sb.AppendLine(" like ");
					sb.AppendLine(f.ColumnValue);
					counter++;
				}
			}

			if (orderByCols.Count > 0) {
				sb.AppendLine("order by ");
				foreach (KeyValuePair<string, string> k in orderByCols) {
					sb.AppendLine(k.Key);
					sb.AppendLine(" ");
					sb.AppendLine(k.Value);
				}
			}

			if (pageSize != -1) {
				const string LIMIT = "limit {0}, {1}";
				int startCount = pageSize * pageNumber;

				sb.AppendLine(string.Format(LIMIT, startCount, pageSize));
			}

			sb.AppendLine(";");
		}

		private string GetSqlWithParams(string sql) {
			StringBuilder sb = new StringBuilder();

			sb.AppendLine(sql);

			foreach (KeyValuePair<string, object> item in parameterCollection) {
				sb.Append(item.Key).Append(':').AppendLine((item.Value == null) ? "null" : item.Value.ToString());
			}

			return sb.ToString();
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vghoghari.org.AppCode.Models;
using Vghoghari.org.AppCode.Utilities;

namespace Vghoghari.org.AppCode.DataLayer {
	internal class SessionDL {
		private static readonly string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString();

		internal static int DeleteSessions(int userId) {
			const string sql = @"update    app_sessions
														set       deleted = 1
																			, modified_date = current_timestamp()
														where     user_id = ?userId
														and       deleted = 0;";

			GlobalDL dl = new GlobalDL();
			dl.AddParameter("userId", userId);

			return dl.ExecuteSqlNonQuery(Utility.ConnectionString, sql);
		}

		internal static int AddSession(Session session) {
			const string sql = @"insert into app_sessions
														(user_id, session_id, expiry_date, user_agent, deleted, created_date, modified_date)
														values
														(?userId, ?sessionId, ?expiryDate, ?userAgent, 0, ?issuedDate, null);
														select LAST_INSERT_ID();";

			GlobalDL dl = new GlobalDL();
			dl.AddParameter("userId", session.UserId);
			dl.AddParameter("sessionId", session.SessionId);
			dl.AddParameter("expiryDate", session.ExpiryDate);
			dl.AddParameter("issuedDate", session.IssuedDate);

			return dl.ExecuteSqlReturnScalar<int>(Utility.ConnectionString, sql);
		}
	}
}
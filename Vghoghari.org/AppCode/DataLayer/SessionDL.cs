using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vghoghari.org.AppCode.Models;
using Vghoghari.org.AppCode.Utilities;

namespace Vghoghari.org.AppCode.DataLayer {
	internal class SessionDL {
		private static readonly string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString();

		internal static int DeleteSessions(int userId, string modifiedBy) {
			const string sql = @"update    app_sessions
														set       deleted = 1
																			, modified_by = ?modifiedBy
																			, modified_date = now()
														where     user_id = ?userId
														and       deleted = 0;";

			GlobalDL dl = new GlobalDL();
			dl.AddParameter("userId", userId);
			dl.AddParameter("modifiedBy", modifiedBy);

			return dl.ExecuteSqlNonQuery(Utility.ConnectionString, sql);
		}

		internal static int DeleteSession(string sessionId) {
			const string sql = @"update    app_sessions s
														left join app_users u
														on        s.user_id = u.id
														set       s.deleted = 1
															        , s.modified_by = u.id
																			, s.modified_date = now()
														where     s.session_id = ?sessionId;";

			GlobalDL dl = new GlobalDL();
			dl.AddParameter("sessionId", sessionId);

			return dl.ExecuteSqlNonQuery(Utility.ConnectionString, sql);
		}

		internal static int AddSession(Session session, string createdBy) {
			const string sql = @"insert into app_sessions
														(user_id, session_id, expiry_date, user_agent, deleted, created_by, created_date, modified_by, modified_date)
														values
														(?userId, ?sessionId, ?expiryDate, ?userAgent, 0, ?createdBy, ?issuedDate, null, null);
														select LAST_INSERT_ID();";

			GlobalDL dl = new GlobalDL();
			dl.AddParameter("userId", session.UserId);
			dl.AddParameter("sessionId", session.SessionId);
			dl.AddParameter("expiryDate", session.ExpiryDate);
			dl.AddParameter("userAgent", session.UserAgent);
			dl.AddParameter("issuedDate", session.IssuedDate);
			dl.AddParameter("createdBy", createdBy);

			return dl.ExecuteSqlReturnScalar<int>(Utility.ConnectionString, sql);
		}
	}
}
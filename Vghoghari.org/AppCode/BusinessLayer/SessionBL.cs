using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vghoghari.org.AppCode.DataLayer;
using Vghoghari.org.AppCode.Models;

namespace Vghoghari.org.AppCode.BusinessLayer {
	public class SessionBL {
		private static readonly string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString();

		public static void DeleteSessions(int userId) {
			SessionDL.DeleteSessions(userId, "system");
		}

		public static void CreateSession(Session session) {
			SessionDL.AddSession(session, "system");
		}
	}
}
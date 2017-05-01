using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using Vghoghari.org.AppCode.BusinessLayer;
using Vghoghari.org.AppCode.Models;

namespace Vghoghari.org.AppCode.Utilities {
	public class UserSessionUtility {

		private static int GetCookieTimeoutValue() {
			int timeout = 1440; //default timeout is 1440 minutes
			XmlDocument webConfig = new XmlDocument();
			webConfig.Load(HttpContext.Current.Server.MapPath(@"~\web.config"));
			XmlNode node = webConfig.SelectSingleNode("/configuration/system.web/authentication/forms");

			if (node != null && node.Attributes["timeout"] != null) {
				timeout = int.Parse(node.Attributes["timeout"].Value);
			}

			return timeout;
		}

		public static void ManageSession(User user, bool isPersistent) {

			// delete all existing session on each user login
			SessionBL.DeleteSessions(user.Id);

			//create new user session for every login
			Session session = new Session();
			session.UserId = user.Id;
			session.SessionId = Guid.NewGuid().ToString();
			session.UserAgent = HttpContext.Current.Request.UserAgent;
			session.IssuedDate = DateTime.Now;

			int getSessionExpiryTime = GetCookieTimeoutValue();
			session.ExpiryDate = session.IssuedDate.AddMinutes(getSessionExpiryTime);

			SessionBL.CreateSession(session);
		}
		
	}
}
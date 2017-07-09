using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Xml;
using Vghoghari.org.AppCode.BusinessLayer;
using Vghoghari.org.AppCode.Models;
using static Vghoghari.org.AppCode.Models.Enum;

namespace Vghoghari.org.AppCode.Utilities {
	public class UserSessionUtility {
		
		public static void ManageSession(User user, bool isPersistent) {

			// delete all existing session on each user login
			SessionBL.DeleteSessions(user.Id);

			//create new user session for every login
			Session session = new Session();
			session.UserId = user.Id;
			session.SessionId = Guid.NewGuid().ToString();
			session.UserAgent = HttpContext.Current.Request.UserAgent;
			session.IssuedDate = DateTime.Now;
			session.ExpiryDate = session.IssuedDate.Date.AddDays(30); // Server side session is issued for 30days after sign up
			SessionBL.CreateSession(session);

			dynamic userData = new {
				Username = user.Username,
				DeviceId = user.DeviceId,
				AuthKey = user.AuthKey,
				UserTypes  = user.UserTypes,
				SessionId = session.SessionId
			};
			CreateUserSession(user.Username, JsonConvert.SerializeObject(userData), isPersistent, string.Empty);
		}

		public static void CreateUserSession(string userName, string userData, bool createPersistentCookie, string strCookiePath) {
			SetAuthCookie(userName, userData, createPersistentCookie, strCookiePath);
		}

		public static void SetAuthCookie(string userName, string userData, bool createPersistentCookie, string strCookiePath) {
			FormsAuthenticationTicket ticket = CreateAuthenticationTicket(userName, userData, createPersistentCookie, strCookiePath);
			string encrypetedTicket = FormsAuthentication.Encrypt(ticket);

			if (!FormsAuthentication.CookiesSupported) {
				//If the authentication ticket is specified not to use cookie, set it in the Uri
				FormsAuthentication.SetAuthCookie(encrypetedTicket, createPersistentCookie);
			}
			else {
				HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypetedTicket);

				if (ticket.IsPersistent) {
					authCookie.Expires = ticket.Expiration;
				}

				HttpContext.Current.Response.Cookies.Add(authCookie);
			}
		}

		private static FormsAuthenticationTicket CreateAuthenticationTicket(string userName, string userData, bool createPersistentCookie, string strCookiePath) {
			string cookiePath = string.IsNullOrWhiteSpace(strCookiePath) ? FormsAuthentication.FormsCookiePath : strCookiePath;
			int expirationMinutes = GetCookieTimeoutValue();

			FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
					1,
					userName,
					DateTime.UtcNow,
					DateTime.UtcNow.AddMinutes(expirationMinutes),
					createPersistentCookie,
					userData,
					cookiePath
			);

			return ticket;
		}

		private static int GetCookieTimeoutValue() {
			int timeout = 1440; //Default timeout is 1440 minutes i.e one day
			XmlDocument webConfig = new XmlDocument();
			webConfig.Load(HttpContext.Current.Server.MapPath(@"~\web.config"));
			XmlNode node = webConfig.SelectSingleNode("/configuration/system.web/authentication/forms");

			if (node != null && node.Attributes["timeout"] != null) {
				timeout = int.Parse(node.Attributes["timeout"].Value);
			}

			return timeout;
		}
	}
}
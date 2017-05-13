using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Vghoghari.org.AppCode.BusinessLayer;
using Vghoghari.org.AppCode.Models;
using Vghoghari.org.Controllers.Base;
using static Vghoghari.org.AppCode.Models.Enum;

namespace Vghoghari.org.AppCode.Attributes {
	public class WebAuthorizeAttribute : AuthorizeAttribute {

		public override void OnAuthorization(AuthorizationContext filterContext) {
			IPrincipal user = filterContext.HttpContext.User;
			if (user != null && user.Identity.IsAuthenticated && user.Identity is FormsIdentity) {
				FormsIdentity id = (FormsIdentity) user.Identity;
				FormsAuthenticationTicket ticket = id.Ticket;

				if (!FormsAuthentication.CookiesSupported) {
					//If cookie is not supported for forms authentication, then the authentication ticket
					// is stored in the Url, which is encrypted. So, decrypt it
					ticket = FormsAuthentication.Decrypt(id.Ticket.Name);
				}

				// Get the stored user-data, in this case, user roles
				if (!string.IsNullOrEmpty(ticket.UserData)) {
					string userData = ticket.UserData;
					dynamic userDetails = JsonConvert.DeserializeObject(userData);

					string deviceId = userDetails.DeviceId;
					string authkey = userDetails.AuthKey;
					string sessionId = userDetails.SessionId;
					int userType = userDetails.UserType;

					User authenticatedUser = AuthenticateUser(deviceId, authkey, sessionId, (enUserType) userType);

					if (authenticatedUser != null) {
						if(filterContext.Controller.GetType().IsSubclassOf(typeof(BaseController))) {
							((BaseController) filterContext.Controller).AuthenticatedUser = authenticatedUser;
						}
						return;
					}
				}
			}

			HandleUnauthorizedRequest(filterContext);
		}

		protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {
			filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "User", action = "Login" }));
		}

		private User AuthenticateUser(string deviceId, string authKey, string sessionId, enUserType userType) {

			User authenticatedUser = UserBL.AuthenticateUser(deviceId, authKey, sessionId);
			if (authenticatedUser.Id > 0 && authenticatedUser.UserType == userType) {
				return authenticatedUser;
			}
			return null;
		}
	}
}
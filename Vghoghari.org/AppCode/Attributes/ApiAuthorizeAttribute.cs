using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Security;
using Vghoghari.org.AppCode.BusinessLayer;
using Vghoghari.org.AppCode.Models;
using Vghoghari.org.Controllers.Base;
using static Vghoghari.org.AppCode.Models.Enum;

namespace Vghoghari.org.AppCode.Attributes {
	public class ApiAuthorizeAttribute: AuthorizeAttribute {

		public override void OnAuthorization(HttpActionContext actionContext) {
			IPrincipal user = actionContext.RequestContext.Principal;
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
					int userType = userDetails.UserType;

					AuthenticatedUser authenticatedUser = AuthenticateUser(deviceId, authkey, (enUserType) userType);

					if (authenticatedUser != null) {
						if (actionContext.ControllerContext.Controller.GetType().IsSubclassOf(typeof(BaseApiController))) {
							((BaseApiController) actionContext.ControllerContext.Controller).AuthenticatedUser = authenticatedUser;
						}
						return;
					}
				}
			}

			HandleUnauthorizedRequest(actionContext);
		}

		protected override void HandleUnauthorizedRequest(HttpActionContext actionContext) {
			actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
		}

		private AuthenticatedUser AuthenticateUser(string deviceId, string authKey, enUserType userType) {

			AuthenticatedUser authenticatedUser = UserBL.AuthenticateUser(deviceId, authKey);
			if (authenticatedUser.User.Id > 0 && !string.IsNullOrWhiteSpace(authenticatedUser.Session.SessionId) && authenticatedUser.User.UserType == userType) {
				return authenticatedUser;
			}
			return null;
		}
	}
}
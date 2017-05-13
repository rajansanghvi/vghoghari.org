using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Vghoghari.org.AppCode.Attributes;
using Vghoghari.org.AppCode.BusinessLayer;
using Vghoghari.org.Controllers.Base;

namespace Vghoghari.org.Controllers {
	public class UserController: BaseController {

		[HttpGet]
		public ActionResult Register() {
			if(HttpContext.User.Identity.IsAuthenticated) {
				return RedirectToAction("Index", "Home");
			}
			return View();
		}

		[HttpGet]
		public ActionResult Login() {
			if(HttpContext.User.Identity.IsAuthenticated) {
				return RedirectToAction("Index", "Home");
			}
			return View();
		}

		[HttpGet]
		[WebAuthorize]
		public void Logout() {
			UserBL.Logout(AuthenticatedUser.SessionId);
			FormsAuthentication.SignOut();
			FormsAuthentication.RedirectToLoginPage();
		}
	}
}
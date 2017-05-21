using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vghoghari.org.AppCode.Attributes;
using Vghoghari.org.AppCode.BusinessLayer;
using Vghoghari.org.Controllers.Base;
using Vghoghari.org.Models;

namespace Vghoghari.org.Controllers {
	public class MatrimonialController: BaseController {

		[HttpGet]
		[WebAuthorize]
		public ActionResult Add(string code) {
			//if(!string.IsNullOrWhiteSpace(code) && !MatrimonialBL.IsUserAuthorisedToBiodata(AuthenticatedUser.Id, code)) {
			//	return RedirectToAction("Manage", "Matrimonial");
			//}

			return View();
		}

		[HttpGet]
		[WebAuthorize]
		public ActionResult Upload(string code) {
			if(string.IsNullOrWhiteSpace(code) || !MatrimonialBL.IsUserAuthorisedToBiodata(AuthenticatedUser.Id, code)) {
				return RedirectToAction("Manage", "Matrimonial");
			}
			return View();
		}

		[HttpGet]
		[WebAuthorize]
		public ActionResult MyBiodata(string code) {
			if (string.IsNullOrWhiteSpace(code)) {
				return RedirectToAction("Manage", "Matrimonial");
			}

			BiodataInfo biodataInfo = MatrimonialBL.GetMyBiodata(AuthenticatedUser.Id, code);

			if (biodataInfo.Id == 0) {
				return RedirectToAction("Manage", "Matrimonial");
			}

			return View(biodataInfo);
		}		
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vghoghari.org.AppCode.Attributes;
using Vghoghari.org.Controllers.Base;

namespace Vghoghari.org.Controllers {
	public class MatrimonialController: BaseController {

		[HttpGet]
		[WebAuthorize]
		public ActionResult Add() {
			return View();
		}
	}
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vghoghari.org.Controllers {
	public class UserController: Controller {

		[HttpGet]
		public ActionResult Register() {
			return View();
		}
	}
}
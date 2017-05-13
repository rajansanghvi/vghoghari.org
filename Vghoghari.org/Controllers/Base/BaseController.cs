using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vghoghari.org.AppCode.Models;

namespace Vghoghari.org.Controllers.Base {
	public class BaseController : Controller {
		internal User AuthenticatedUser { get; set; }

		public BaseController() {
			this.AuthenticatedUser = new User();
		}
	}
}
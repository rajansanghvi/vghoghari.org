﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vghoghari.org.AppCode.Models;

namespace Vghoghari.org.Controllers.Base {
	public class BaseApiController: ApiController {
		internal User AuthenticatedUser { get; set; }

		public BaseApiController() {
			this.AuthenticatedUser = new User();
		}
	}
}

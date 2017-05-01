using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vghoghari.org.AppCode.BusinessLayer;
using Vghoghari.org.AppCode.Models;
using static Vghoghari.org.AppCode.Models.Enum;

namespace Vghoghari.org.Controllers {
	public class ExternalController: ApiController {

		[HttpPost]
		public IHttpActionResult Register(dynamic data) {
			string fullName = data.FullName;
			string username = data.Username;
			string password = data.Password;
			string confirmedPassword = data.ConfirmedPassword;
			string mobileNumber = data.MobileNumber;
			string emailId = data.EmailId;
			string religion = data.Religion;

			enRegistrationResponse response = UserBL.Register(fullName, username, password, confirmedPassword, mobileNumber, emailId, religion);

			switch (response) {
				case enRegistrationResponse.DataValidationError:
					return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "There is some data validation error in the registration data sent. Please correct the errors and try again later. Thank you!"));
				case enRegistrationResponse.UsernameNotAvailable:
					return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.Conflict, "The username requested is already in use by a different user. We request you to please choose another username and try again. Thank you!"));
				default:
					return ResponseMessage(Request.CreateResponse(HttpStatusCode.Created));
			}
		}

		public IHttpActionResult Login(dynamic data) {
			string username = data.Username;
			string password = data.Password;

			KeyValuePair<enLoginResponse, User> response = UserBL.Login(username, password);

			switch (response.Key) {
				case enLoginResponse.DataValidationError:
					return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "There is some data validation error in the login credentials sent. Please correct the errors and try again later. Thank you!"));
				case enLoginResponse.UserInactive:
					return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.Forbidden, "Sorry, the account associated with the login credential sent is inactive and hence cannot be accessed. Please contact admin for further actions. Thank you!"));
				case enLoginResponse.UserNotFound:
					return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Sorry, the login credentials provided is not a valid combination. Please retry using valid username and password. Thank you!"));
				default:

					return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));
			}
		}
	}
}

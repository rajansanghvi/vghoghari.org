using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vghoghari.org.AppCode.BusinessLayer;
using Vghoghari.org.AppCode.Models;
using Vghoghari.org.AppCode.Utilities;
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
			
			enRegistrationResponse response = UserBL.Register(fullName.Trim(), username.Trim(), password.Trim(), confirmedPassword.Trim(), mobileNumber.Trim(), emailId.Trim());

			switch (response) {
				case enRegistrationResponse.DataValidationError:
					return BadRequest("There are some data validation errors in the registration data sent. Please correct the errors and try again later. Thank you!");
				case enRegistrationResponse.UsernameNotAvailable:
					return Content(HttpStatusCode.Conflict, "The username requested is already in use by a different user. We request you to please choose another username and try again. Thank you!");
				default:
					return Content(HttpStatusCode.Created, string.Empty);
			}
		}

		[HttpPost]
		public IHttpActionResult Login(dynamic data) {
			string username = data.Username;
			string password = data.Password;
			bool createPersistentCookie = data.IsPersistent;

			KeyValuePair<enLoginResponse, User> response = UserBL.Login(username, password);

			switch (response.Key) {
				case enLoginResponse.DataValidationError:
					return BadRequest("There are some data validation errors in the login credential sent. Please correct the errors and try again later. Thank you!");
				case enLoginResponse.UserInactive:
					return Content(HttpStatusCode.Forbidden, "Sorry, the account associated with the login credential sent is inactive and hence cannot be accessed. Please contact admin for further actions. Thank you!");
				case enLoginResponse.UserNotFound:
					return Content(HttpStatusCode.Unauthorized, "Sorry, the login credential provided is not valid. Please retry using valid username and password. Thank you!");
				default:
					UserSessionUtility.ManageSession(response.Value, createPersistentCookie);
					return Ok();
			}
		}

		[HttpPost]
		public bool UsernameAvailable(string username) {
			return UserBL.UsernameAvailable(username.Trim());
		}

		[HttpGet]
		public List<KeyValuePair<string, string>> GetCities(int countryCode) {
			return AppBL.GetCities(countryCode);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Vghoghari.org.AppCode.DataLayer;
using Vghoghari.org.AppCode.Models;
using Vghoghari.org.AppCode.Utilities;
using static Vghoghari.org.AppCode.Models.Enum;

namespace Vghoghari.org.AppCode.BusinessLayer {
	public class UserBL {
		private static readonly string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString();

		private static enRegistrationResponse ValidateRegistrationData(string fullName, string username, string password, string confirmedPassword, string mobileNumber, string emailId, string religion) {
			if (string.IsNullOrWhiteSpace(fullName)
				|| !Regex.IsMatch(fullName, @"^([A-Za-z]{1,})([ ]{0,1})([A-Za-z]{1,})?([ ]{0,1})?([A-Za-z]{1,})?([ ]{0,1})?([A-Za-z]{1,})$")) {
				return enRegistrationResponse.DataValidationError;
			}

			if (string.IsNullOrWhiteSpace(username)
				|| !Regex.IsMatch(username, @"^(?!.*\.\.)(?!.*\.$)[^\W][\w.]{0,29}$")) {
				return enRegistrationResponse.DataValidationError;
			}
			else {
				bool usernameExists = UserDL.UsernameExists(username);
				if (usernameExists) {
					return enRegistrationResponse.UsernameNotAvailable;
				}
			}

			if (string.IsNullOrWhiteSpace(password)
				|| !Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d!$%@#£€*?&]{8,16}$")) {
				return enRegistrationResponse.DataValidationError;
			}

			if (!string.Equals(password, confirmedPassword)) {
				return enRegistrationResponse.DataValidationError;
			}

			if (string.IsNullOrWhiteSpace(mobileNumber)
				|| !Regex.IsMatch(mobileNumber, @"^(\+)?(\d){0,3}( )?\d{4,15}$")) {
				return enRegistrationResponse.DataValidationError;
			}

			if (!string.IsNullOrWhiteSpace(emailId)
				&& !Regex.IsMatch(emailId, @"^([\w\.\-_]+)?\w+@[\w-_]+(\.\w+){1,}$")) {
				return enRegistrationResponse.DataValidationError;
			}

			if (!string.IsNullOrWhiteSpace(religion)
				&& !Regex.IsMatch(religion, @"^(?=.*[a-zA-Z\d].*)[a-zA-Z\d !@#$%&*()\-_+=:;""',./?]{2,}$")) {
				return enRegistrationResponse.DataValidationError;
			}

			return enRegistrationResponse.Ok;
		}

		private static KeyValuePair<string, string> GenerateUniqueAppKeys() {
			//Fetch all existing deviceIds and authKeys
			KeyValuePair<HashSet<string>, HashSet<string>> appKeys = UserDL.FetchAllAppKeys();

			string deviceId = string.Empty;
			string authKey = string.Empty;

			while (true) {
				deviceId = Utility.GetUniqueKey(25, false, false);
				authKey = Utility.GetUniqueKey(40, true, false);

				if (!appKeys.Key.Contains(deviceId) && !appKeys.Value.Contains(authKey)) {
					break;
				}
				else {
					continue;
				}
			}

			return new KeyValuePair<string, string>(deviceId, authKey);
		}

		public static enRegistrationResponse Register(string fullName, string username, string password, string confirmedPassword, string mobileNumber, string emailId, string religion) {
			enRegistrationResponse response = ValidateRegistrationData(fullName, username, password, confirmedPassword, mobileNumber, emailId, religion);

			if (response != enRegistrationResponse.Ok) {
				return response;
			}

			enUserType userType = enUserType.User; //By default all users that register to the website are created as Users and not admin or super admins
			string hashedPassword = Utility.GetMd5Hash(password);
			KeyValuePair<string, string> appKeys = GenerateUniqueAppKeys();

			int userId = UserDL.AddUserDetails(fullName, username, hashedPassword, appKeys.Key, appKeys.Value, userType, mobileNumber, emailId, religion);

			if (userId > 0) {
				return enRegistrationResponse.Ok;
			}
			else {
				throw new Exception();
			}
		}

		private static enLoginResponse ValidateLoginData(string username, string password) {
			if (string.IsNullOrWhiteSpace(username)
				|| !Regex.IsMatch(username, @"^(?!.*\.\.)(?!.*\.$)[^\W][\w.]{0,29}$")) {
				return enLoginResponse.DataValidationError;
			}

			if (string.IsNullOrWhiteSpace(password)
				|| !Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d!$%@#£€*?&]{8,16}$")) {
				return enLoginResponse.DataValidationError;
			}

			return enLoginResponse.Ok;
		}

		public static KeyValuePair<enLoginResponse, User> Login(string username, string password) {
			enLoginResponse response = ValidateLoginData(username, password);

			if(response != enLoginResponse.Ok) {
				return new KeyValuePair<enLoginResponse, User>(response, null);
			}

			string hashedPassword = Utility.GetMd5Hash(password);
			User user = UserDL.FetchUser(username, hashedPassword);

			if(user == null) {
				return new KeyValuePair<enLoginResponse, User>(enLoginResponse.UserNotFound, null);
			}

			if(user.Deleted) {
				return new KeyValuePair<enLoginResponse, User>(enLoginResponse.UserInactive, null);
			}

			return new KeyValuePair<enLoginResponse, User>(enLoginResponse.Ok, user);
		}
	}
}
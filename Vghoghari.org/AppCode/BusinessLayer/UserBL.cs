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
		private const string REGEX_FULLNAME = @"^(-?([A-Z].\s)?([A-Z][a-z]+)\s?)+([A-Z]'([A-Z][a-z]+))?$";
		private const string REGEX_USERNAME = @"^(?!.*\.\.)(?!.*\.$)[^\W][\w.]{0,29}$";
		private const string REGEX_PASSWORD = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$";
		private const string REGEX_MOBILE_NUMBER = @"^[789]\d{9}$";
		private const string REGEX_EMAIL_ID = @"^([\w\.\-_]+)?\w+@[\w-_]+(\.\w+){1,}$";

		private static enRegistrationResponse ValidateRegistrationData(string fullName, string username, string password, string confirmedPassword, string mobileNumber, string emailId) {

			// Fullname can consists only alphabets. this regex is not case sensitive
			if (string.IsNullOrWhiteSpace(fullName)
				|| !Regex.IsMatch(fullName, REGEX_FULLNAME, RegexOptions.IgnoreCase)) {
				return enRegistrationResponse.DataValidationError;
			}

			// Usernames can contain characters a-z, 0-9, underscores and periods. The username cannot start with a period nor end with a period. It must also not have more than one period sequentially. Max length is 30 chars.
			if (string.IsNullOrWhiteSpace(username)
				|| !Regex.IsMatch(username, REGEX_USERNAME)) {
				return enRegistrationResponse.DataValidationError;
			}
			else {
				bool usernameExists = UserDL.UsernameExists(username);
				if (usernameExists) {
					return enRegistrationResponse.UsernameNotAvailable;
				}
			}

			// at least 8 characters, must contain at least 1 uppercase letter, 1 lowercase letter, and 1 number, Can contain special characters
			if (string.IsNullOrWhiteSpace(password)
				|| !Regex.IsMatch(password, REGEX_PASSWORD)) {
				return enRegistrationResponse.DataValidationError;
			}

			if (!string.Equals(password, confirmedPassword)) {
				return enRegistrationResponse.DataValidationError;
			}

			// only 10 digits starting with 7,8 or 9
			if (string.IsNullOrWhiteSpace(mobileNumber)
				|| !Regex.IsMatch(mobileNumber, REGEX_MOBILE_NUMBER)) {
				return enRegistrationResponse.DataValidationError;
			}

			// valid email id.
			if (!string.IsNullOrWhiteSpace(emailId)
				&& !Regex.IsMatch(emailId, REGEX_EMAIL_ID)) {
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

		public static enRegistrationResponse Register(string fullName, string username, string password, string confirmedPassword, string mobileNumber, string emailId) {
			enRegistrationResponse response = ValidateRegistrationData(fullName, username, password, confirmedPassword, mobileNumber, emailId);

			if (response != enRegistrationResponse.Ok) {
				return response;
			}

			// By default all users that register to the website are created with User Role
			enUserType userType = enUserType.User; 
			string hashedPassword = Utility.GetMd5Hash(password);
			KeyValuePair<string, string> appKeys = GenerateUniqueAppKeys();
			
			int userId = UserDL.AddUserDetails(fullName, username, hashedPassword, appKeys.Key, appKeys.Value, userType, mobileNumber, emailId);

			if (userId > 0) {
				return enRegistrationResponse.Ok;
			}
			else {
				throw new Exception();
			}
		}

		private static enLoginResponse ValidateLoginData(string username, string password) {
			if (string.IsNullOrWhiteSpace(username)
				|| !Regex.IsMatch(username, REGEX_USERNAME)) {
				return enLoginResponse.DataValidationError;
			}

			if (string.IsNullOrWhiteSpace(password)
				|| !Regex.IsMatch(password, REGEX_PASSWORD)) {
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

		public static User AuthenticateUser(string deviceId, string authKey, string sessionId) {
			return UserDL.FetchAuthenticatedUser(deviceId, authKey, sessionId);
			
		}

		public static bool UsernameAvailable(string username) {
			return !UserDL.UsernameExists(username);
		}

		public static void Logout(string sessionId) {
			SessionBL.DeleteSession(sessionId);
		}
	}
}
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vghoghari.org.AppCode.Models;
using Vghoghari.org.AppCode.Utilities;
using static Vghoghari.org.AppCode.Models.Enum;

namespace Vghoghari.org.AppCode.DataLayer {
	internal class UserDL {

		private static readonly string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString();

		internal static bool UsernameExists(string username) {
			const string sql = @"select    1
														from      app_users
														where     lower(username) = lower(?username);";

			GlobalDL dl = new GlobalDL();
			dl.AddParameter("username", username);

			return dl.ExecuteSqlReturnScalar<int>(Utility.ConnectionString, sql) == 1 ? true : false;
		}

		internal static KeyValuePair<HashSet<string>, HashSet<string>> FetchAllAppKeys() {
			const string sql = @"select    device_id as device_id
																		, auth_key as auth_key
													from      app_users;";

			GlobalDL dl = new GlobalDL();

			HashSet<string> deviceIds = new HashSet<string>();
			HashSet<string> authKeys = new HashSet<string>();

			using (MySqlDataReader dr = dl.ExecuteSqlReturnReader(Utility.ConnectionString, sql)) {
				while (dr.Read()) {
					deviceIds.Add(dr.GetString("device_id"));
					authKeys.Add(dr.GetString("auth_key"));
				}
			}

			return new KeyValuePair<HashSet<string>, HashSet<string>>(deviceIds, authKeys);
		}

		internal static int AddUserDetails(string fullName, string username, string hashedPassword, string deviceId, string authKey, string mobileNumber, string emailId) {
			const string sql = @"insert into app_users
														(fullname, username, hashed_password, device_id, auth_key, mobile_number, email_id,  deleted, created_by, created_date, modified_by, modified_date)
														values
														(?fullName, ?username, ?hashedPassword, ?deviceId, ?authKey, ?mobileNumber, ?emailId, 0, ?username, now(), null, null);
														select LAST_INSERT_ID();";

			GlobalDL dl = new GlobalDL();
			dl.AddParameter("fullName", fullName);
			dl.AddParameter("username", username);
			dl.AddParameter("hashedPassword", hashedPassword);
			dl.AddParameter("deviceId", deviceId);
			dl.AddParameter("authKey", authKey);
			dl.AddParameter("mobileNumber", mobileNumber);
			dl.AddParameter("emailId", emailId);

			return dl.ExecuteSqlReturnScalar<int>(Utility.ConnectionString, sql);
		}

		internal static int AddUserType(int userId, enUserType userType, string createdBy = "system") {
			const string sql = @"insert into app_user_types
													(user_id, user_type, deleted, created_by, created_date, modified_by, modified_date)
													values
													(?userId, ?userType, 0, ?createdBy, now(), null, null);
													select LAST_INSERT_ID();";

			GlobalDL dl = new GlobalDL();
			dl.AddParameter("userId", userId);
			dl.AddParameter("userType", userType);
			dl.AddParameter("createdBy", createdBy);

			return dl.ExecuteSqlReturnScalar<int>(Utility.ConnectionString, sql);
		}

		internal static User FetchUser(string username, string hashedPassword) {
			const string sql = @"select    id as id
																			, ifnull(username, '') as username
																			, ifnull(device_id, '') as device_id
																			, ifnull(auth_key, '') as auth_key
																			, ifnull(deleted, 0) as deleted
														from      app_users
														where     lower(username) = lower(?username)
														and       hashed_password = ?hashedPassword;";

			GlobalDL dl = new GlobalDL();
			dl.AddParameter("username", username);
			dl.AddParameter("hashedPassword", hashedPassword);

			using (MySqlDataReader dr = dl.ExecuteSqlReturnReader(Utility.ConnectionString, sql)) {
				if (dr.Read()) {
					return new User() {
						Id = dr.GetInt32("id"),
						Username = dr.GetString("username"),
						DeviceId = dr.GetString("device_id"),
						AuthKey = dr.GetString("auth_key"),
						Deleted = dr.GetBoolean("deleted")
					};
				}
			}

			return new User();
		}

		internal static List<enUserType> FetchUserTypesForUser(int userId) {
			const string sql = @"select  user_type as user_type
													from    app_user_types
													where   deleted = 0
													and     user_id = ?userId;";

			GlobalDL dl = new GlobalDL();
			dl.AddParameter("userId", userId);

			List<enUserType> userTypes = new List<enUserType>();
			using (MySqlDataReader dr = dl.ExecuteSqlReturnReader(Utility.ConnectionString, sql)) {
				while (dr.Read()) {
					userTypes.Add((enUserType) dr.GetInt32("user_type"));
				}
			}

			return userTypes;
		}

		internal static User FetchAuthenticatedUser(string deviceId, string authkey, string sessionId) {
			const string sql = @"select    u.id as id
																		, ifnull(u.fullname, '') as fullname
																		, ifnull(u.username, '') as username
																		, ifnull(u.device_id, '') as device_id
																		, ifnull(u.user_type, 1) as user_type
																		, ifnull(u.mobile_number, '') as mobile_number
																		, ifnull(u.email_id, '') as email_id
																		, ifnull(s.session_id, '') as session_id
													from      app_users u
													left join app_sessions s
													on        u.id = s.user_id
													where     u.device_id = ?deviceId
													and       u.auth_key = ?authKey
													and       u.deleted = 0
													and       ifnull(s.expiry_date, now()) >= now()
													and       s.deleted = 0
													and				s.session_id = ?sessionId;";

			GlobalDL dl = new GlobalDL();
			dl.AddParameter("deviceId", deviceId);
			dl.AddParameter("authKey", authkey);
			dl.AddParameter("sessionId", sessionId);

			using (MySqlDataReader dr = dl.ExecuteSqlReturnReader(Utility.ConnectionString, sql)) {
				if (dr.Read()) {
					return new User() {
						Id = dr.GetInt32("id"),
						FullName = dr.GetString("fullname"),
						Username = dr.GetString("username"),
						DeviceId = dr.GetString("device_id"),
						UserType = (enUserType) dr.GetInt32("user_type"),
						MobileNumber = dr.GetString("mobile_number"),
						EmailId = dr.GetString("email_id"),
						SessionId = dr.GetString("session_id")
					};
				}
			}

			return new User();
		}
	}
}
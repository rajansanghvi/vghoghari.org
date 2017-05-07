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

		internal static int AddUserDetails(string fullName, string username, string hashedPassword, string deviceId, string authKey, enUserType userType, string mobileNumber, string emailId, string religion) {
			const string sql = @"insert into app_users
														(fullname, username, hashed_password, device_id, auth_key, user_type, mobile_number, email_id, religion, deleted, created_by, created_date, modified_by, modified_date)
														values
														(?fullName, ?username, ?hashedPassword, ?deviceId, ?authKey, ?userType, ?mobileNumber, ?emailId, ?religion, 0, ?username, now(), null, null);
														select LAST_INSERT_ID();";

			GlobalDL dl = new GlobalDL();
			dl.AddParameter("fullName", fullName);
			dl.AddParameter("username", username);
			dl.AddParameter("hashedPassword", hashedPassword);
			dl.AddParameter("deviceId", deviceId);
			dl.AddParameter("authKey", authKey);
			dl.AddParameter("userType", userType);
			dl.AddParameter("mobileNumber", mobileNumber);
			dl.AddParameter("emailId", emailId);
			dl.AddParameter("religion", religion);

			return dl.ExecuteSqlReturnScalar<int>(Utility.ConnectionString, sql);
		}

		internal static User FetchUser(string username, string hashedPassword) {
			const string sql = @"select    id as id
																			, ifnull(username, '') as username
																			, ifnull(device_id, '') as device_id
																			, ifnull(auth_key, '') as auth_key
																			, ifnull(user_type, 1) as user_type
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
						UserType = (enUserType) dr.GetInt32("user_type"),
						Deleted = dr.GetBoolean("deleted")
					};
				}
			}

			return null;
		}
	}
}
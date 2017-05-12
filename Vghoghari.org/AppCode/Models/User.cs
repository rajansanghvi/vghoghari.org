using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vghoghari.org.AppCode.Utilities;
using static Vghoghari.org.AppCode.Models.Enum;

namespace Vghoghari.org.AppCode.Models {
	public class User {

		[JsonIgnore]
		public int Id { get; set; }
		public string FullName { get; set; }
		public string Username { get; set; }
		public string DeviceId { get; set; }
		public string AuthKey { get; set; }
		public enUserType UserType { get; set; }
		public string MobileNumber { get; set; }
		public string EmailId { get; set; }
		public string Religion { get; set; }
		public bool Deleted { get; set; }

		public User() {
			Id = 0;
			FullName = string.Empty;
			Username = string.Empty;
			DeviceId = string.Empty;
			AuthKey = string.Empty;
			UserType = enUserType.User;
			MobileNumber = string.Empty;
			EmailId = string.Empty;
			Religion = string.Empty;
			Deleted = false;
		}
	}

	public class Session {
		[JsonIgnore]
		public int Id { get; set; }
		[JsonIgnore]
		public int UserId { get; set; }
		public string SessionId { get; set; }
		public string UserAgent { get; set; }
		public DateTime ExpiryDate { get; set; }
		public Int64 UtcExpiryData {
			get {
				return DateUtility.GetUnixTimeStamp(ExpiryDate);
			}
		}
		public DateTime IssuedDate { get; set; }
		public Int64 UtcIssuedDate {
			get {
				return DateUtility.GetUnixTimeStamp(IssuedDate);
			}
		}
		public bool Deleted { get; set; }

		public Session() {
			Id = 0;
			UserId = 0;
			SessionId = string.Empty;
			UserAgent = string.Empty;
			IssuedDate = DateTime.UtcNow;
			ExpiryDate = DateTime.UtcNow.AddDays(1); // default expiry is 1 day 
			Deleted = false;
		}
	}

	public class AuthenticatedUser {
		public User User { get; set; }
		public Session Session { get; set; }

		public AuthenticatedUser() {
			User = new User();
			Session = new Session();
		}
	}
}
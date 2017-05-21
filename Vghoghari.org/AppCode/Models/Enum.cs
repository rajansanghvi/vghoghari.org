using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vghoghari.org.AppCode.Models {
	public class Enum {

		public enum enRegistrationResponse {
			DataValidationError = 1,
			UsernameNotAvailable = 2,
			Ok = 3
		}

		public enum enUserType {
			User = 1,
			Admin = 2,
			SuperAdmin = 3
		}

		public enum enLoginResponse {
			DataValidationError = 1,
			UserNotFound = 2,
			UserInactive = 3,
			Ok = 4
		}

		public enum enAddBiodataResponse {
			DataValidationError = 1,
			Ok = 2,
			Forbidden = 3
		}

		public enum enBiodataApprovalStatus {
			Incomplete = 1,
			Pending = 2,
			Approved = 3,
			Rejected = 4
		}
	}
}
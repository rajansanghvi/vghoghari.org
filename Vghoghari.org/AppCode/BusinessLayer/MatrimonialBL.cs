using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Web;
using Vghoghari.org.AppCode.DataLayer;
using Vghoghari.org.AppCode.Models;
using Vghoghari.org.AppCode.Utilities;
using Vghoghari.org.Models;
using static Vghoghari.org.AppCode.Models.Enum;

namespace Vghoghari.org.AppCode.BusinessLayer {
	public class MatrimonialBL {
		private static readonly string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString();
		private const string REGEX_FULLNAME = @"^(-?([A-Z].\s)?([A-Z][a-z]*)\s?)+([A-Z]'([A-Z][a-z]*))?$";
		private const string REGEX_MOBILE_NUMBER = @"^[789]\d{9}$";
		private const string REGEX_EMAIL_ID = @"^([\w\.\-_]+)?\w+@[\w-_]+(\.\w+){1,}$";

		private static enAddBiodataResponse ValidateBiodataInfo(BiodataInfo biodataInfo) {
			if (string.IsNullOrWhiteSpace(biodataInfo.BasicInfo.Gender)) {
				return enAddBiodataResponse.DataValidationError;
			}

			if (string.IsNullOrWhiteSpace(biodataInfo.BasicInfo.FullName)
				|| !Regex.IsMatch(biodataInfo.BasicInfo.FullName, REGEX_FULLNAME, RegexOptions.IgnoreCase)) {
				return enAddBiodataResponse.DataValidationError;
			}

			if (biodataInfo.BasicInfo.Dob.Date.CompareTo(new DateTime(1970, 1, 1).Date) <= 0) {
				return enAddBiodataResponse.DataValidationError;
			}
			else if (biodataInfo.BasicInfo.Dob.Date.CompareTo(DateTime.Today.Date.AddYears(-18)) > 0) {
				return enAddBiodataResponse.DataValidationError;
			}

			if (string.IsNullOrWhiteSpace(biodataInfo.BasicInfo.MaritalStatus)) {
				return enAddBiodataResponse.DataValidationError;
			}

			if (string.IsNullOrWhiteSpace(biodataInfo.BasicInfo.Native)) {
				return enAddBiodataResponse.DataValidationError;
			}

			if (!string.IsNullOrWhiteSpace(biodataInfo.BasicInfo.BirthPlace)) {
				biodataInfo.BasicInfo.BirthPlace = Utility.RemoveHtml(biodataInfo.BasicInfo.BirthPlace);
			}

			if (string.IsNullOrWhiteSpace(biodataInfo.BasicInfo.Caste)) {
				return enAddBiodataResponse.DataValidationError;
			}

			if (biodataInfo.PersonalInfo.HeightFt == 0) {
				return enAddBiodataResponse.DataValidationError;
			}

			if (string.IsNullOrWhiteSpace(biodataInfo.EducationInfo.Education)) {
				return enAddBiodataResponse.DataValidationError;
			}

			if (!string.IsNullOrWhiteSpace(biodataInfo.EducationInfo.EducationDetails)) {
				biodataInfo.EducationInfo.EducationDetails = Utility.RemoveHtml(biodataInfo.EducationInfo.EducationDetails);
			}

			if (string.IsNullOrWhiteSpace(biodataInfo.OccupationInfo.Occupation)) {
				return enAddBiodataResponse.DataValidationError;
			}

			if (!string.IsNullOrWhiteSpace(biodataInfo.OccupationInfo.ProfessionDetails)) {
				biodataInfo.OccupationInfo.ProfessionDetails = Utility.RemoveHtml(biodataInfo.OccupationInfo.ProfessionDetails);
			}

			if (string.IsNullOrWhiteSpace(biodataInfo.FamilyInfo.FatherName)
				|| !Regex.IsMatch(biodataInfo.FamilyInfo.FatherName, REGEX_FULLNAME, RegexOptions.IgnoreCase)) {
				return enAddBiodataResponse.DataValidationError;
			}

			if (string.IsNullOrWhiteSpace(biodataInfo.FamilyInfo.MotherName)
				|| !Regex.IsMatch(biodataInfo.FamilyInfo.MotherName, REGEX_FULLNAME, RegexOptions.IgnoreCase)) {
				return enAddBiodataResponse.DataValidationError;
			}

			if (biodataInfo.FamilyInfo.NoOfMarriedBro < 0) {
				return enAddBiodataResponse.DataValidationError;
			}

			if (biodataInfo.FamilyInfo.NoOfMarriedSis < 0) {
				return enAddBiodataResponse.DataValidationError;
			}

			if (biodataInfo.FamilyInfo.NoOfUnmarriedBro < 0) {
				return enAddBiodataResponse.DataValidationError;
			}

			if (biodataInfo.FamilyInfo.NoOfUnmarriedSis < 0) {
				return enAddBiodataResponse.DataValidationError;
			}

			if (!string.IsNullOrWhiteSpace(biodataInfo.FamilyInfo.FamilyDetails)) {
				biodataInfo.FamilyInfo.FamilyDetails = Utility.RemoveHtml(biodataInfo.FamilyInfo.FamilyDetails);
			}

			if (string.IsNullOrWhiteSpace(biodataInfo.MosalInfo.MosalName)
				|| !Regex.IsMatch(biodataInfo.MosalInfo.MosalName, REGEX_FULLNAME, RegexOptions.IgnoreCase)) {
				return enAddBiodataResponse.DataValidationError;
			}

			biodataInfo.MosalInfo.MosalNative = Utility.RemoveHtml(biodataInfo.MosalInfo.MosalNative);
			if (string.IsNullOrWhiteSpace(biodataInfo.MosalInfo.MosalNative)) {
				return enAddBiodataResponse.DataValidationError;
			}

			biodataInfo.ContactInfo.Address = Utility.RemoveHtml(biodataInfo.ContactInfo.Address);
			if (string.IsNullOrWhiteSpace(biodataInfo.ContactInfo.Address)) {
				return enAddBiodataResponse.DataValidationError;
			}

			if (string.IsNullOrWhiteSpace(biodataInfo.ContactInfo.MobileNumber)
				|| !Regex.IsMatch(biodataInfo.ContactInfo.MobileNumber, REGEX_MOBILE_NUMBER)) {
				return enAddBiodataResponse.DataValidationError;
			}

			if (!string.IsNullOrWhiteSpace(biodataInfo.ContactInfo.EmailId)
				&& !Regex.IsMatch(biodataInfo.ContactInfo.EmailId, REGEX_EMAIL_ID)) {
				return enAddBiodataResponse.DataValidationError;
			}

			return enAddBiodataResponse.Ok;
		}

		public static KeyValuePair<enAddBiodataResponse, BiodataInfo> AddBiodata(int userId, BiodataInfo biodataInfo) {
			enAddBiodataResponse validationResponse = ValidateBiodataInfo(biodataInfo);
			if (validationResponse != enAddBiodataResponse.Ok) {
				return new KeyValuePair<enAddBiodataResponse, BiodataInfo>(validationResponse, null);
			}

			using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required)) {
				try {
					biodataInfo.Code = Guid.NewGuid().ToString();
					biodataInfo.Id = MatrimonialDL.AddBasicInfo(userId, biodataInfo.Code, biodataInfo.BasicInfo);
					MatrimonialDL.AddPersonalInfo(biodataInfo.Id, biodataInfo.PersonalInfo);
					MatrimonialDL.AddEducationalInfo(biodataInfo.Id, biodataInfo.EducationInfo);
					MatrimonialDL.AddOccupationInfo(biodataInfo.Id, biodataInfo.OccupationInfo);
					MatrimonialDL.AddFamilyDetails(biodataInfo.Id, biodataInfo.FamilyInfo);
					MatrimonialDL.AddMosalInfo(biodataInfo.Id, biodataInfo.MosalInfo);
					MatrimonialDL.AddContactInfo(biodataInfo.Id, biodataInfo.ContactInfo);

					ts.Complete();
				}
				catch (Exception ex) {
					ts.Dispose();
					throw ex;
				}
			}

			return new KeyValuePair<enAddBiodataResponse, BiodataInfo>(validationResponse, biodataInfo);
		}

		public static bool IsUserAuthorisedToBiodata(int userId, string code) {
			return MatrimonialDL.BiodataExists(userId, code);
		}

		public static enAddBiodataResponse SaveProfilePicture(int userId, string code, string imageData) {
			if (string.IsNullOrWhiteSpace(imageData)) {
				return enAddBiodataResponse.DataValidationError;
			}

			if (!IsUserAuthorisedToBiodata(userId, code)) {
				return enAddBiodataResponse.Forbidden;
			}

			try {
				string actualData = imageData.Split(',')[1];
				byte[] data = Convert.FromBase64String(actualData);
				string fileName = Guid.NewGuid().ToString();

				string directoryPath = HttpContext.Current.Server.MapPath("~/AppData/biodata/profile_images/");
				if (!Directory.Exists(directoryPath)) {
					Directory.CreateDirectory(directoryPath);
				}
				
				File.WriteAllBytes(string.Format("{0}{1}.jpg", directoryPath, fileName), data);
				string oldFileName = MatrimonialDL.FetchProfileImage(code);
				MatrimonialDL.SaveProfileImage(code, fileName, userId.ToString());

				if (!string.IsNullOrWhiteSpace(oldFileName) && File.Exists(string.Format("{0}{1}.jpg", directoryPath, oldFileName))) {
					File.Delete(string.Format("{0}{1}.jpg", directoryPath, oldFileName));
				}

				return enAddBiodataResponse.Ok;
			}
			catch (Exception ex) {
				throw ex;
			}
		}

		public static BiodataInfo GetMyBiodata(int userId, string code) {
			return MatrimonialDL.FetchBiodata(userId, code);
		}
	}
}
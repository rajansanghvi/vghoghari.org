using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vghoghari.org.AppCode.Attributes;
using Vghoghari.org.AppCode.BusinessLayer;
using Vghoghari.org.Controllers.Base;
using Vghoghari.org.Models;
using static Vghoghari.org.AppCode.Models.Enum;

namespace Vghoghari.org.Controllers {
	public class MatrimonialApiController: BaseApiController {

		[HttpPost]
		[ApiAuthorize]
		public IHttpActionResult Add(dynamic data) {

			string gender = data.Gender;
			string fullname = data.FullName;
			string dob = data.Dob;
			string birthTime = data.BirthTime;
			string maritalStatus = data.MaritalStatus;
			string native = data.Native;
			string birthPlace = data.BirthPlace;
			string caste = data.Caste;

			string heightFt = data.HeightFt;
			string heightIn = data.HeightIn;
			string weight = data.Weight;
			string bloodGroup = data.BloodGroup;
			string manglik = data.Manglik;
			string horoscopeMatch = data.HoroscopeMatch;
			string foodHabits = data.FoodHabits;

			string education = data.Education;
			string[] degrees = null;
			if (data.Degrees != null) {
				degrees = data.Degrees.ToObject<string[]>();
			}
			string educationDetails = data.EducationDetails;

			string occupation = data.Occupation;
			string[] professionSector = null;
			if (data.ProfessionSector != null) {
				professionSector = data.ProfessionSector.ToObject<string[]>();
			}
			string annualIncome = data.AnnualIncome;
			string professionDetails = data.ProfessionDetails;

			string fatherName = data.FatherName;
			string motherName = data.MotherName;
			int noOfMarriedBro = data.NoOfMarriedBro;
			int noOfMarriedSis = data.NoOfMarriedSis;
			int noOfUnmarriedBro = data.NoOfUnmarriedBro;
			int noOfUnmarriedSis = data.NoOfUnmarriedSis;
			string familyDetails = data.FamilyDetails;

			string mosalName = data.MosalName;
			string mosalNative = data.MosalNative;

			string address = data.Address;
			string city = data.City;
			string mobileNumber = data.MobileNumber;
			string emailId = data.EmailId;

			BasicInfo basicInfo = new BasicInfo();
			basicInfo.Gender = gender;
			basicInfo.FullName = fullname;

			if (!string.IsNullOrWhiteSpace(dob)) {
				basicInfo.Dob = DateTime.Parse(dob);
			}
			if(!string.IsNullOrWhiteSpace(birthTime)) {
				DateTime time = DateTime.Parse(birthTime);
				basicInfo.Dob = basicInfo.Dob.AddHours(time.Hour);
				basicInfo.Dob = basicInfo.Dob.AddMinutes(time.Minute);
			}
			basicInfo.MaritalStatus = maritalStatus;
			basicInfo.Native = native;
			basicInfo.BirthPlace = birthPlace;
			basicInfo.Caste = caste;

			PersonalInfo personalInfo = new PersonalInfo();
			if(!string.IsNullOrWhiteSpace(heightFt)) {
				personalInfo.HeightFt = Int32.Parse(heightFt);
			}
			if(!string.IsNullOrWhiteSpace(heightIn)) {
				personalInfo.HeightIn = Int32.Parse(heightIn);
			}
			if(!string.IsNullOrWhiteSpace(weight)) {
				personalInfo.Weight = (float) Decimal.Parse(weight);
			}
			personalInfo.BloodGroup = bloodGroup;
			personalInfo.HoroscopeMatch = horoscopeMatch;
			personalInfo.Manglik = manglik;
			personalInfo.FoodHabits = foodHabits;

			EducationInfo educationInfo = new EducationInfo();
			educationInfo.Education = education;
			if(degrees != null) {
				educationInfo.Degrees = degrees.ToList();
			}
			educationInfo.EducationDetails = educationDetails;

			OccupationInfo occupationInfo = new OccupationInfo();
			occupationInfo.Occupation = occupation;
			if(professionSector != null) {
				occupationInfo.ProfessionSector = professionSector.ToList();
			}
			if(!string.IsNullOrWhiteSpace(annualIncome)) {
				occupationInfo.AnnualIncome = Decimal.Parse(annualIncome);
			}
			occupationInfo.ProfessionDetails = professionDetails;

			FamilyInfo familyInfo = new FamilyInfo();
			familyInfo.FatherName = fatherName;
			familyInfo.MotherName = motherName;
			familyInfo.NoOfMarriedBro = noOfMarriedBro;
			familyInfo.NoOfMarriedSis = noOfMarriedSis;
			familyInfo.NoOfUnmarriedBro = noOfUnmarriedBro;
			familyInfo.NoOfUnmarriedSis = noOfUnmarriedSis;
			familyInfo.FamilyDetails = familyDetails;

			MosalInfo mosalInfo = new MosalInfo();
			mosalInfo.MosalName = mosalName;
			mosalInfo.MosalNative = mosalNative;

			ContactInfo contactInfo = new ContactInfo();
			contactInfo.Address = address;
			contactInfo.City = city;
			contactInfo.MobileNumber = mobileNumber;
			contactInfo.EmailId = emailId;

			BiodataInfo biodataInfo = new BiodataInfo();
			biodataInfo.BasicInfo = basicInfo;
			biodataInfo.PersonalInfo = personalInfo;
			biodataInfo.EducationInfo = educationInfo;
			biodataInfo.OccupationInfo = occupationInfo;
			biodataInfo.FamilyInfo = familyInfo;
			biodataInfo.MosalInfo = mosalInfo;
			biodataInfo.ContactInfo = contactInfo;

			KeyValuePair<enAddBiodataResponse, BiodataInfo> response = MatrimonialBL.AddBiodata(AuthenticatedUser.Id,  biodataInfo);

			switch (response.Key) {
				case enAddBiodataResponse.DataValidationError:
					return BadRequest("There are some data validation errors in the biodata details sent.Please correct the errors and try again later. Thank you!");
				default:
					return Content(HttpStatusCode.Created, response.Value.Code);
			}
		}

		[HttpPost]
		[ApiAuthorize]
		public IHttpActionResult Upload(dynamic data) {
			string code = data.Code;
			string imageData = data.ImageData;

			enAddBiodataResponse response = MatrimonialBL.SaveProfilePicture(AuthenticatedUser.Id, code, imageData);

			switch (response) {
				case enAddBiodataResponse.DataValidationError:
					return BadRequest("Sorry, there is no image available. We request you to please select a profile image and try again later.");
				case enAddBiodataResponse.Forbidden:
					return Content(HttpStatusCode.Forbidden, "Sorry, your account does not have access rights to modify this biodata. Please try again.");
				default:
					return Ok(code);
			}
		}

		[HttpGet]
		[ApiAuthorize]
		public IHttpActionResult GetMyBiodata(string code) {
			BiodataInfo biodataInfo = MatrimonialBL.GetMyBiodata(AuthenticatedUser.Id, -);
			if(biodataInfo.Id > 0) {
				return Ok(biodataInfo);
			}

			return Content(HttpStatusCode.Forbidden, "Sorry, your account does not have access rights to modify this biodata. Please try again.");
		}
	}
}

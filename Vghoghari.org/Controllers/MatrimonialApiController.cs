using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vghoghari.org.AppCode.Attributes;
using Vghoghari.org.Controllers.Base;

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

			int heightFt = data.HeightFt;
			int heightIn = data.HeightIn;
			float weight = data.Weight;
			string bloodGroup = data.BloodGroup;
			string manglik = data.Manglik;
			string horoscopeMatch = data.HoroscoptMatch;
			string foodHabits = data.FoodHabits;

			string education = data.Education;
			string[] degrees = data.Degrees.ToObject<string[]>();
			string educationDetails = data.EducationDetails;

			string occupation = data.Occupation;
			string[] professionSector = data.ProfessionSector.ToObject<string[]>();
			double annualIncome = data.AnnualIncome;
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
			
			return Ok();
		}
	}
}

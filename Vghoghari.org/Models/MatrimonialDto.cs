using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vghoghari.org.Models {
	public class BasicInfo {
		public string Gender { get; set; }
		public string Fullname { get; set; }
		public DateTime Dob { get; set; }
		public string MaritalStatus { get; set; }
		public string Native { get; set; }
		public string BirthPlace { get; set; }
		public string Caste { get; set; }

		public BasicInfo() {
			Gender = string.Empty;
			Fullname = string.Empty;
			Dob = DateTime.Today;
			MaritalStatus = string.Empty;
			Native = string.Empty;
			BirthPlace = string.Empty;
			Caste = string.Empty;
		}
	}

	public class PersonalInfo {
		public int HeightFt { get; set; }
		public int HeightIn { get; set; }
		public float Weight { get; set; }
		public string BloodGroup { get; set; }
		public string Manglik { get; set; }
		public string HoroscopeMatch { get; set; }
		public string FoodHabits { get; set; }

		public PersonalInfo() {
			HeightFt = 0;
			HeightIn = 0;
			Weight = 0;
			BloodGroup = string.Empty;
			Manglik = string.Empty;
			HoroscopeMatch = string.Empty;
			FoodHabits = string.Empty;
		}
	}

	public class EducationInfo {
		public string Education { get; set; }
		public string Degrees { get; set; }
		public string EducationDetails { get; set; }

		public EducationInfo() {
			Education = string.Empty;
			Degrees = string.Empty;
			EducationDetails = string.Empty;
		}
	}

	public class OccupationInfo {
		public string Occupation { get; set; }
		public string ProfessionSector { get; set; }
		public decimal AnnualIncome { get; set; }
		public string ProfessionDetails { get; set; }

		public OccupationInfo() {
			Occupation = string.Empty;
			ProfessionSector = string.Empty;
			AnnualIncome = 0;
			ProfessionDetails = string.Empty;
		}
	}

	public class FamilyInfo {
		public string FatherName { get; set; }
		public string MotherName { get; set; }
		public int NoOfMarriedBro { get; set; }
		public int NoOfMarriedSis { get; set; }
		public int NoOfUnmarriedBro { get; set; }
		public int NoOfUnmarriedSis { get; set; }
		public string FamilyDetails { get; set; }

		public FamilyInfo() {
			FatherName = string.Empty;
			MotherName = string.Empty;
			NoOfMarriedBro = 0;
			NoOfMarriedSis = 0;
			NoOfUnmarriedBro = 0;
			NoOfUnmarriedSis = 0;
			FamilyDetails = string.Empty;
		} 
	}
}
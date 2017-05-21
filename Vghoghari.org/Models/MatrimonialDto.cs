using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Vghoghari.org.AppCode.Models.Enum;

namespace Vghoghari.org.Models {
	public class BiodataInfo {
		[JsonIgnore]
		public int Id { get; set; }
		public string Code { get; set; }
		public enBiodataApprovalStatus ApprovalStatus { get; set; }
		[JsonIgnore]
		public int UserId { get; set; }
		public string ProfileImage { get; set; }

		public BasicInfo BasicInfo { get; set; }
		public PersonalInfo PersonalInfo { get; set; }
		public EducationInfo EducationInfo { get; set; }
		public OccupationInfo OccupationInfo { get; set; }
		public FamilyInfo FamilyInfo { get; set; }
		public MosalInfo MosalInfo { get; set; }
		public ContactInfo ContactInfo { get; set; }

		public BiodataInfo() {
			Id = 0;
			Code = string.Empty;
			ApprovalStatus = enBiodataApprovalStatus.Pending;
			BasicInfo = new BasicInfo();
			PersonalInfo = new PersonalInfo();
			EducationInfo = new EducationInfo();
			OccupationInfo = new OccupationInfo();
			FamilyInfo = new FamilyInfo();
			MosalInfo = new MosalInfo();
			ContactInfo = new ContactInfo();
		}
	}

	public class BasicInfo {
		public string Gender { get; set; }
		public string FullName { get; set; }
		public DateTime Dob { get; set; }
		public string MaritalStatus { get; set; }
		public string Native { get; set; }
		public string BirthPlace { get; set; }
		public string Caste { get; set; }

		public BasicInfo() {
			Gender = string.Empty;
			FullName = string.Empty;
			Dob = new DateTime(1970, 1, 1);
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
		public List<string> Degrees { get; set; }
		public string EducationDetails { get; set; }

		[JsonIgnore]
		public string DegreesString { get; set; }

		public EducationInfo() {
			Education = string.Empty;
			Degrees = new List<string>();
			EducationDetails = string.Empty;
			DegreesString = string.Empty;
		}
	}

	public class OccupationInfo {
		public string Occupation { get; set; }
		public List<string> ProfessionSector { get; set; }
		public decimal AnnualIncome { get; set; }
		public string ProfessionDetails { get; set; }

		[JsonIgnore]
		public string ProfessionSectorString { get; set; }

		public OccupationInfo() {
			Occupation = string.Empty;
			ProfessionSector = new List<string>();
			AnnualIncome = 0;
			ProfessionDetails = string.Empty;
			ProfessionSectorString = string.Empty;
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

	public class MosalInfo {
		public string MosalName { get; set; }
		public string MosalNative { get; set; }

		public MosalInfo() {
			MosalName = string.Empty;
			MosalNative = string.Empty;
		}
	}

	public class ContactInfo {
		public string Address { get; set; }
		public string City { get; set; }
		public string MobileNumber { get; set; }
		public string EmailId { get; set; }

		public ContactInfo() {
			Address = string.Empty;
			City = string.Empty;
			MobileNumber = string.Empty;
			EmailId = string.Empty;
		}
	}
}
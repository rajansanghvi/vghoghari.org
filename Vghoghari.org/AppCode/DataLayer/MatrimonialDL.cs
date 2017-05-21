using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vghoghari.org.AppCode.Utilities;
using Vghoghari.org.Models;
using static Vghoghari.org.AppCode.Models.Enum;

namespace Vghoghari.org.AppCode.DataLayer {
	internal class MatrimonialDL {

		internal static int AddBasicInfo(int userId, string code, BasicInfo basicInfo) {
			const string sql = @"insert into app_biodata_basic_infos
													(user_id, code, gender, fullname, dob, marital_status, native, birth_place, caste, approval_status, last_admin_action_by, last_admin_action_date, deleted, created_by, created_date, modified_name, modified_date)
													values
													(?userId, ?code, ?gender, ?fullName, ?dob, ?maritalStatus, ?native, ?birthPlace, ?caste, 1, null, null, 0, ?userId, now(), null, null);
													select last_insert_id();";

			GlobalDL dl = new GlobalDL();
			dl.AddParameter("userId", userId);
			dl.AddParameter("code", code);
			dl.AddParameter("gender", basicInfo.Gender);
			dl.AddParameter("fullName", basicInfo.FullName);
			dl.AddParameter("dob", basicInfo.Dob);
			dl.AddParameter("maritalStatus", basicInfo.MaritalStatus);
			dl.AddParameter("native", basicInfo.Native);
			dl.AddParameter("birthPlace", basicInfo.BirthPlace);
			dl.AddParameter("caste", basicInfo.Caste);

			return dl.ExecuteSqlReturnScalar<int>(Utility.ConnectionString, sql);
		}

		internal static int AddPersonalInfo(int biodataId, PersonalInfo personalInfo) {
			const string sql = @"insert into app_biodata_personal_infos
													(biodata_id, height_ft, height_in, weight, blood_group, manglik, horoscope_match, food_habits)
													values
													(?biodataId, ?heightFt, ?heightIn, ?weight, ?bloodGroup, ?manglik, ?horoscopeMatch, ?foodHabits);
													select last_insert_id();";

			GlobalDL dl = new GlobalDL();
			dl.AddParameter("biodataId", biodataId);
			dl.AddParameter("heightFt", personalInfo.HeightFt);
			dl.AddParameter("heightIn", personalInfo.HeightIn);
			dl.AddParameter("weight", personalInfo.Weight);
			dl.AddParameter("bloodGroup", personalInfo.BloodGroup);
			dl.AddParameter("manglik", personalInfo.Manglik);
			dl.AddParameter("horoscopeMatch", personalInfo.HoroscopeMatch);
			dl.AddParameter("foodHabits", personalInfo.FoodHabits);

			return dl.ExecuteSqlReturnScalar<int>(Utility.ConnectionString, sql);
		}

		internal static int AddEducationalInfo(int biodataId, EducationInfo educationInfo) {
			const string sql = @"insert into app_biodata_education_infos
													(biodata_id, education, degrees_achieved, details)
													values
													(?biodataId, ?education, ?degreesAchieved, ?details);
													select last_insert_id();";

			GlobalDL dl = new GlobalDL();
			dl.AddParameter("biodataId", biodataId);
			dl.AddParameter("education", educationInfo.Education);
			dl.AddParameter("degreesAchieved", string.Join(",", educationInfo.Degrees));
			dl.AddParameter("details", educationInfo.EducationDetails);

			return dl.ExecuteSqlReturnScalar<int>(Utility.ConnectionString, sql);
		}

		internal static int AddOccupationInfo(int biodataId, OccupationInfo occupationInfo) {
			const string sql = @"insert into app_biodata_occupation_infos
													(biodata_id, occupation, profession_sector, annual_income, details)
													values
													(?biodataId, ?occupation, ?professionSector, ?annualIncome, ?details);
													select last_insert_id()";

			GlobalDL dl = new GlobalDL();
			dl.AddParameter("biodataId", biodataId);
			dl.AddParameter("occupation", occupationInfo.Occupation);
			dl.AddParameter("professionSector", string.Join(",", occupationInfo.ProfessionSector));
			dl.AddParameter("annualIncome", occupationInfo.AnnualIncome);
			dl.AddParameter("details", occupationInfo.ProfessionDetails);

			return dl.ExecuteSqlReturnScalar<int>(Utility.ConnectionString, sql);
		}

		internal static int AddFamilyDetails(int biodataId, FamilyInfo familyInfo) {
			const string sql = @"insert into app_biodata_family_infos
													(biodata_id, father_name, mother_name, no_of_married_bro, no_of_married_sis, no_of_unmarried_bro, no_of_unmarried_sis, details)
													values
													(?biodataId, ?fatherName, ?motherName, ?noOfMarriedBro, ?noOfMarriedSis, ?noOfUnmarriedBro, ?noOfUnmarriedSis, ?details);
													select last_insert_id();";

			GlobalDL dl = new GlobalDL();
			dl.AddParameter("biodataId", biodataId);
			dl.AddParameter("fatherName", familyInfo.FatherName);
			dl.AddParameter("motherName", familyInfo.MotherName);
			dl.AddParameter("noOfMarriedBro", familyInfo.NoOfMarriedBro);
			dl.AddParameter("noOfMarriedSis", familyInfo.NoOfMarriedSis);
			dl.AddParameter("noOfUnmarriedBro", familyInfo.NoOfUnmarriedBro);
			dl.AddParameter("noOfUnmarriedSis", familyInfo.NoOfUnmarriedSis);
			dl.AddParameter("details", familyInfo.FamilyDetails);

			return dl.ExecuteSqlReturnScalar<int>(Utility.ConnectionString, sql);
		}

		internal static int AddMosalInfo(int biodataId, MosalInfo mosalInfo) {
			const string sql = @"insert into app_biodata_mosal_infos
														(biodata_id, mosal_name, mosal_native)
														values
														(?biodataId, ?mosalName, ?mosalNative);
														select last_insert_id();";

			GlobalDL dl = new GlobalDL();
			dl.AddParameter("biodataId", biodataId);
			dl.AddParameter("mosalName", mosalInfo.MosalName);
			dl.AddParameter("mosalNative", mosalInfo.MosalNative);

			return dl.ExecuteSqlReturnScalar<int>(Utility.ConnectionString, sql);
		}

		internal static int AddContactInfo(int biodataId, ContactInfo contactInfo) {
			const string sql = @"insert into app_biodata_contact_infos
														(biodata_id, address, city, mobile_number, email_id )
														values
														(?biodataId, ?address, ?city, ?mobileNumber, ?emailId);
														select last_insert_id();";

			GlobalDL dl = new GlobalDL();
			dl.AddParameter("biodataId", biodataId);
			dl.AddParameter("address", contactInfo.Address);
			dl.AddParameter("city", contactInfo.City);
			dl.AddParameter("mobileNumber", contactInfo.MobileNumber);
			dl.AddParameter("emailId", contactInfo.EmailId);

			return dl.ExecuteSqlReturnScalar<int>(Utility.ConnectionString, sql);
		}

		internal static bool BiodataExists(int userId, string code) {
			const string sql = @"select    1
														from      app_biodata_basic_infos
														where     user_id = ?userId
														and       code = ?code
														and       deleted = 0;";

			GlobalDL dl = new GlobalDL();
			dl.AddParameter("userId", userId);
			dl.AddParameter("code", code);

			return dl.ExecuteSqlReturnScalar<int>(Utility.ConnectionString, sql) == 1 ? true : false;
		}

		internal static string FetchProfileImage(string code) {
			const string sql = @"select    ifnull(profile_image, '')
														from      app_biodata_basic_infos
														where     code = ?code;";

			GlobalDL dl = new GlobalDL();
			dl.AddParameter("code", code);

			return dl.ExecuteSqlReturnScalar<string>(Utility.ConnectionString, sql);
		}

		internal static int SaveProfileImage(string code, string fileName, string modifiedBy) {
			const string sql = @"update    app_biodata_basic_infos
														set       profile_image = ?fileName
																			, approval_status = 2
																			, modified_by = ?modifiedBy
																			, modified_date = now()
														where     code = ?code;";

			GlobalDL dl = new GlobalDL();
			dl.AddParameter("fileName", fileName);
			dl.AddParameter("modifiedBy", modifiedBy);
			dl.AddParameter("code", code);

			return dl.ExecuteSqlNonQuery(Utility.ConnectionString, sql);
		}

		internal static BiodataInfo FetchBiodata(int userId, string code) {
			const string sql = @"select    b.id as id
																		,	b.user_id as user_id
																		, b.gender as gender
																		, b.fullname as fullname
																		, b.dob as dob
																		, b.marital_status as marital_status
																		, b.native as native
																		, ifnull(b.birth_place, '') as birth_place
																		, b.caste as caste
																		, ifnull(b.profile_image, '') as profile_image
																		, b.approval_status as approval_status
																		, p.height_ft as height_ft
																		, p.height_in as height_in
																		, ifnull(p.weight, 0) as weight
																		, ifnull(p.blood_group, '') as blood_group
																		, ifnull(p.manglik, '') as manglik
																		, ifnull(p.horoscope_match, '') as horoscope_match
																		, p.food_habits as food_habits
																		, e.education as education
																		, ifnull(e.degrees_achieved, '') as degrees_achieved
																		, IFNULL(e.details, '') as education_details
																		, o.occupation as occupation
																		, ifnull(o.profession_sector, '') as profession_sector
																		, ifnull(o.annual_income, 0) as annual_income
																		, ifnull(o.details, '') as occupation_details
																		, f.father_name as father_name
																		, f.mother_name as mother_name
																		, f.no_of_married_bro as no_of_married_bro 
																		, f.no_of_married_sis as no_of_married_sis
																		, f.no_of_unmarried_bro as no_of_unmarried_bro
																		, f.no_of_unmarried_sis as no_of_unmarried_sis
																		, ifnull(f.details, '') as family_details
																		, m.mosal_name as mosal_name
																		, m.mosal_native as mosal_native
																		, c.address as address
																		, ifnull(c.city, '') as city
																		, c.mobile_number as mobile_number
																		, ifnull(c.email_id, '') as email_id
													from      app_biodata_basic_infos b
													left join app_biodata_personal_infos p
													on        b.id = p.biodata_id
													left join app_biodata_education_infos e
													on        b.id = e.biodata_id
													left join app_biodata_occupation_infos o
													on        b.id = o.biodata_id
													left join app_biodata_family_infos f
													on        b.id = f.biodata_id
													left join app_biodata_mosal_infos m
													on        b.id = f.biodata_id
													left join app_biodata_contact_infos c
													on        b.id = c.biodata_id
													where     b.code = ?code
													and       b.user_id = ?userId
													and       b.deleted = 0;";

			GlobalDL dl = new GlobalDL();
			dl.AddParameter("code", code);
			dl.AddParameter("userId", userId);

			using (MySqlDataReader dr =  dl.ExecuteSqlReturnReader(Utility.ConnectionString, sql)) {
				if (dr.Read()) {
					BiodataInfo biodataInfo = new BiodataInfo();
					biodataInfo.Id = dr.GetInt32("id");
					biodataInfo.UserId = dr.GetInt32("user_id");
					biodataInfo.ApprovalStatus = (enBiodataApprovalStatus) dr.GetInt32("approval_status");
					biodataInfo.ProfileImage = dr.GetString("profile_image");

					BasicInfo basicInfo = new BasicInfo();
					basicInfo.Gender = dr.GetString("gender");
					basicInfo.FullName = dr.GetString("fullname");
					basicInfo.Dob = dr.GetDateTime("dob");
					basicInfo.MaritalStatus = dr.GetString("marital_status");
					basicInfo.Native = dr.GetString("native");
					basicInfo.BirthPlace = dr.GetString("birth_place");
					basicInfo.Caste = dr.GetString("caste");

					PersonalInfo personalInfo = new PersonalInfo();
					personalInfo.HeightFt = dr.GetInt32("height_ft");
					personalInfo.HeightIn = dr.GetInt32("height_in");
					personalInfo.Weight = dr.GetFloat("weight");
					personalInfo.BloodGroup = dr.GetString("blood_group");
					personalInfo.Manglik = dr.GetString("manglik");
					personalInfo.HoroscopeMatch = dr.GetString("horoscope_match");
					personalInfo.FoodHabits = dr.GetString("food_habits");

					EducationInfo educationInfo = new EducationInfo();
					educationInfo.Education = dr.GetString("education");
					educationInfo.DegreesString = dr.GetString("degrees_achieved");
					educationInfo.EducationDetails = dr.GetString("education_details");

					OccupationInfo occupationInfo = new OccupationInfo();
					occupationInfo.Occupation = dr.GetString("occupation");
					occupationInfo.ProfessionSectorString = dr.GetString("profession_sector");
					occupationInfo.AnnualIncome = dr.GetDecimal("annual_income");
					occupationInfo.ProfessionDetails = dr.GetString("occupation_details");

					FamilyInfo familyInfo = new FamilyInfo();
					familyInfo.FatherName = dr.GetString("father_name");
					familyInfo.MotherName = dr.GetString("mother_name");
					familyInfo.NoOfMarriedBro = dr.GetInt32("no_of_married_bro");
					familyInfo.NoOfMarriedSis = dr.GetInt32("no_of_married_sis");
					familyInfo.NoOfUnmarriedBro = dr.GetInt32("no_of_unmarried_bro");
					familyInfo.NoOfUnmarriedSis = dr.GetInt32("no_of_unmarried_sis");
					familyInfo.FamilyDetails = dr.GetString("family_details");

					MosalInfo mosalInfo = new MosalInfo();
					mosalInfo.MosalName = dr.GetString("mosal_name");
					mosalInfo.MosalNative = dr.GetString("mosal_native");

					ContactInfo contactInfo = new ContactInfo();
					contactInfo.Address = dr.GetString("address");
					contactInfo.City = dr.GetString("city");
					contactInfo.MobileNumber = dr.GetString("mobile_number");
					contactInfo.EmailId = dr.GetString("email_id");

					biodataInfo.BasicInfo = basicInfo;
					biodataInfo.PersonalInfo = personalInfo;
					biodataInfo.EducationInfo = educationInfo;
					biodataInfo.OccupationInfo = occupationInfo;
					biodataInfo.FamilyInfo = familyInfo;
					biodataInfo.MosalInfo = mosalInfo;
					biodataInfo.ContactInfo = contactInfo;

					return biodataInfo;
				}
			}

			return new BiodataInfo();
		}
	}
}
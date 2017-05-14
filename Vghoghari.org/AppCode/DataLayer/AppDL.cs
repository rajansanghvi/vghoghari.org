using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vghoghari.org.AppCode.Utilities;

namespace Vghoghari.org.AppCode.DataLayer {
	internal class AppDL {

		internal static List<KeyValuePair<string, string>> FetchCities(int countryId) {
			const string sql = @"select    ifnull(name, '') as name
																		, ifnull(value, '') as value
													from      app_cities
													where     country_id = ?countryId
													order by	lower(name) asc;";

			GlobalDL dl = new GlobalDL();
			dl.AddParameter("countryId", countryId);

			List<KeyValuePair<string, string>> cities = new List<KeyValuePair<string, string>>();

			using (MySqlDataReader dr =  dl.ExecuteSqlReturnReader(Utility.ConnectionString, sql)) {
				while(dr.Read()) {
					cities.Add(new KeyValuePair<string, string>(dr.GetString("name"), dr.GetString("value")));
				}
			}

			return cities;
		}
	}
}
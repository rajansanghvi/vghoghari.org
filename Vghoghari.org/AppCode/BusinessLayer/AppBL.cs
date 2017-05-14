using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vghoghari.org.AppCode.DataLayer;

namespace Vghoghari.org.AppCode.BusinessLayer {
	public class AppBL {

		public static List<KeyValuePair<string, string>> GetCities(int countryId) {
			return AppDL.FetchCities(countryId);
		}

	}
}
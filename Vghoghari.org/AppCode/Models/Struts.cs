using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vghoghari.org.AppCode.Models {
	public class DateRange {
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }

		public DateRange(DateTime startDate, DateTime endDate) {
			this.StartDate = startDate;
			this.EndDate = endDate;

			this.EndDate = this.EndDate.AddHours(23).AddMinutes(59).AddSeconds(59);
		}

		public override string ToString() {
			return this.StartDate.ToString() + " :: " + this.EndDate.ToString();
		}
	}

	public class FilterDto {
		public string ColumnName { get; set; }
		public string Operator { get; set; }
		public string ColumnValue { get; set; }
	}
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
	public class Customer
	{
		[Key]
		public int CustomerID { get; set; }
		public string MobileNumber { get; set; }
		public DateTime CreatedDate { get; set; }
		public int OTPNO { get; set; }
		public string CreatedBy { get; set; }
		public int ICNumber { get; set; }

		public virtual CustomerOtp CustomerOtp { get; set; }
	}
}

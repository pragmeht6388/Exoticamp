using Exoticamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CustomerOtp.Query.GetByCustomerId
{
	public class CustomerOtpVM
	{
		[Key]
		public int OtpId { get; set; }

		public int? CustomerID { get; set; }

		public DateTime CreatedDate { get; set; }
		public int OtpNo { get; set; }
		public string CreatedBy { get; set; }

		[ForeignKey("CustomerID")]
		public virtual Domain.Entities.Customer Customer { get; set; }
	}
}

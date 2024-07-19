using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exoticamp.Domain.Entities
{
	public class CustomerOtp
	{
		[Key]
		public int OtpId { get; set; }

		public int? CustomerID { get; set; }

		public DateTime CreatedDate{ get; set; }
		public int OtpNo { get; set; }
		public string CreatedBy {  get; set; }

		[ForeignKey("CustomerID")]
		public virtual Customer Customer { get; set; }

	}
}

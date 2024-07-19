using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
	public class CustomerConsent
	{

		[Key]
		public int ConsentId {  get; set; }
		public int CustomerId {  get; set; }

		public string CreatedBy {  get; set; }
		public DateTime CreatedDate { get; set; }

		[ForeignKey("CustomerId")]
		public virtual Customer Customer { get; set; }

	}
}

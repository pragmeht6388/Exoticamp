using Exoticamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exoticamp.Application.Features.Campsite.Commands.AddCampsite;
using MediatR;
using Exoticamp.Application.Responses;

namespace Exoticamp.Application.Features.CustomerOtp.Commands.AddCustomerOtp
{
	public class AddCustomerOtpCommand : IRequest<Response<CustomerOtpDto>>
	{

		

		public int? CustomerID { get; set; }

		public DateTime CreatedDate { get; set; }
		public int OtpNo { get; set; }
		public string CreatedBy { get; set; }

		[ForeignKey("CustomerID")]
		public virtual Customer Customer { get; set; }
	}
}

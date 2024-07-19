using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CustomerOtp.Query.GetByCustomerId
{
	public class GetCustomerOtpQuery : IRequest<Response<CustomerOtpVM>>
	{
		public int Id { get; set; }
	}
}

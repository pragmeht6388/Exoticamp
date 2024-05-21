using Exoticamp.Application.Responses;
using MediatR;
using Exoticamp.Application.Features.Categories.Queries.GetCategory;
using System;
using System.Collections.Generic;
using System.Linq;  
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Products.Queries.GetProduct
{
    public class GetProductDetailQuery : IRequest<Response<ProductVM>>
    {
        public string Id { get; set; }
    }
}

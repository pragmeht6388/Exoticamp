using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Products.Commands.AddProduct
{
    public class AddProductCommand : IRequest<Response<ProductDto>>
    {

        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}

using MediatR;
using MyCleanProject1.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCleanProject1.Application.Features.Products.Commands.AddProduct
{
    public class AddProductCommand:IRequest<Response<ProductDto>>
    {
        
        public string Name { get; set; }
        public decimal Price { get; set; }  
    }
}

using MediatR;
using MyCleanProject1.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCleanProject1.Application.Features.Products.Queries.GetProductList
{
    public class GetProductListQuery:IRequest<Response<IEnumerable<ProductVM>>>
    {
    }
}

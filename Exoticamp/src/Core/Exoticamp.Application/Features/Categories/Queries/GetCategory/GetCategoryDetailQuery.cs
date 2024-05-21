using Exoticamp.Application.Responses;
using MediatR;

namespace Exoticamp.Application.Features.Categories.Queries.GetCategory
{
    public class GetCategoryDetailQuery : IRequest<Response<CategoryVM>>
    {
        public string Id { get; set; }
    }
}

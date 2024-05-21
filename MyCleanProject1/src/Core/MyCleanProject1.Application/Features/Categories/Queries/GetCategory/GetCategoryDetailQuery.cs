using MediatR;
using MyCleanProject1.Application.Response;

namespace MyCleanProject1.Application.Features.Categories.Queries.GetCategory
{
    public class GetCategoryDetailQuery : IRequest<Response<CategoryVM>>
    {
        public string Id { get; set; }
    }
}

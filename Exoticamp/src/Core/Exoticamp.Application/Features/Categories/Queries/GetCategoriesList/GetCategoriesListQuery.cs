using MediatR;
using System.Collections.Generic;
using Exoticamp.Application.Responses;

namespace Exoticamp.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<Response<IEnumerable<CategoryListVm>>>
    {
    }
}

using MediatR;
using System.Collections.Generic;
using Exoticamp.Application.Responses;

namespace Exoticamp.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class GetCategoriesListWithEventsQuery : IRequest<Response<IEnumerable<CategoryEventListVm>>>
    {
        public bool IncludeHistory { get; set; }
    }
}

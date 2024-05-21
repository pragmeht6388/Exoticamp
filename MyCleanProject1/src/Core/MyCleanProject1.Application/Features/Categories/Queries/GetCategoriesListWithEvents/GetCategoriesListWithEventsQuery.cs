using MyCleanProject1.Application.Response;
using MediatR;
using System.Collections.Generic;

namespace MyCleanProject1.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class GetCategoriesListWithEventsQuery: IRequest<Response<IEnumerable<CategoryEventListVm>>>
    {
        public bool IncludeHistory { get; set; }
    }
}

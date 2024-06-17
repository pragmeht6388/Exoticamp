using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Search.Query.GetSearchResults
{
    public class GetSearchResultQuery:IRequest<Response<SearchDto>>
    {
        public string Text { get; set; }
    }

}

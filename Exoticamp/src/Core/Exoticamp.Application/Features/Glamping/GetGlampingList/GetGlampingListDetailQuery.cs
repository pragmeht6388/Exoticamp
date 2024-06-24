using Exoticamp.Application.Features.Banners.Queries;
using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Glamping.GetGlampingList
{
    public class GetGlampingListDetailQuery: IRequest<Response<IEnumerable<GetGlampingListDto>>>
    {
    }
}

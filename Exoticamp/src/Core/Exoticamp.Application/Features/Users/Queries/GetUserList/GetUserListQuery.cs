using Exoticamp.Application.Features.Categories.Queries.GetCategoriesList;
using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Users.Queries.GetUserList
{
    public class GetUserListQuery: IRequest<Response<IEnumerable< GetUserListDto>>>
    {
    }
}

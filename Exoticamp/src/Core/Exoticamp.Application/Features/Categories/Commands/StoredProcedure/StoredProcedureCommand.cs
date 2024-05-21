using MediatR;
using Exoticamp.Application.Responses;

namespace Exoticamp.Application.Features.Categories.Commands.StoredProcedure
{
    public class StoredProcedureCommand : IRequest<Response<StoredProcedureDto>>
    {
        public string Name { get; set; }
    }
}

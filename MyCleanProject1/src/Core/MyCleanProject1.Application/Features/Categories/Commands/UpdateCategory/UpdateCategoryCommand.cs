using MediatR;
using MyCleanProject1.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCleanProject1.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<Response<UpdateCategoryDto>>
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }

    }
}

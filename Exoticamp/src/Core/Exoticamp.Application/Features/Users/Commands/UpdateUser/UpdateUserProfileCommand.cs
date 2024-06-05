using Exoticamp.Application.Models.Authentication;
using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserProfileCommand : IRequest<Response<string>>
    {

        public string Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public Guid LocationId { get; set; }
        public Guid PreferenceId { get; set; }
    }
}

using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.Banners.Commands.DeleteBanner;
using Exoticamp.Application.Features.Banners.Commands.UpdateBanner;
using Exoticamp.Application.Features.Events.Commands.DeleteEvent;
using Exoticamp.Application.Models.Authentication;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;

        public DeleteUserCommandHandler(IMapper mapper,  IUserRepository userRepository  , IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _messageRepository = messageRepository;
        }

        //public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var userToDelete = await _userRepository.GetByIdAsync(Guid.Parse(request.Id));

        //        if (userToDelete == null)
        //        {
        //            throw new NotFoundException(nameof(Banner), request.Id);
        //        }

        //        // Perform the deletion logic here
        //        // For example, you can mark the banner as inactive or delete it from the database
        //        userToDelete.IsDeleted= false; // Marking the banner as inactive

        //        // Update the database
        //        await _userRepository.UpdateAsync(userToDelete);

        //        return Unit.Value;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log or handle the exception appropriately
        //        throw; // Rethrow the exception to maintain consistency in error handling
        //    }
        //}
    }
}

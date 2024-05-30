using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.Products.Commands.UpdateProduct;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Campsite.Commands.UpdateCampsite
{
    internal class UpdatecampsiteHandler : IRequestHandler<UpdateCampsiteCommand, Response<UpdateCampsiteDto>>
    {
        private readonly ICampsiteRepository _campsiteRepository;
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;

        public UpdatecampsiteHandler(IMapper mapper, ICampsiteRepository campsiteRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _campsiteRepository = campsiteRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<UpdateCampsiteDto>> Handle(UpdateCampsiteCommand request, CancellationToken cancellationToken)
        {
            var campsiteToUpdate = await _campsiteRepository.GetByIdAsync(request.Id);

            if (campsiteToUpdate == null)
            {
                throw new NotFoundException(nameof(Campsite), request.Id);
            }

            // Check if the campsite is active
            if (campsiteToUpdate.isActive==false)
            {
                throw new InvalidOperationException("Cannot update an inactive campsite.");
            }

            var validator = new updateCampsiteCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            _mapper.Map(request, campsiteToUpdate);

            await _campsiteRepository.UpdateAsync(campsiteToUpdate);

            var dto = new UpdateCampsiteDto
            {
                Id = request.Id,
                Name = request.Name,
                Location = request.Location,
                Status = request.Status,
                TentType = request.TentType,
                isActive = request.isActive,
                ApprovedBy = request.ApprovedBy,
                ApprovededDate = request.ApprovededDate,
                DeletededBy = request.DeletededBy,
                DeletedDate = request.DeletedDate
            };

            return new Response<UpdateCampsiteDto>(dto, "Updated successfully");
        }



    }
}

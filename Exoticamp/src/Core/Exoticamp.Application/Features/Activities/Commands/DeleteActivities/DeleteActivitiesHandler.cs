using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.CampsiteDetails.Commands.DeleteCampsiteDetails;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Activities.Commands.DeleteActivities
{
    public class DeleteActivitiesHandler : IRequestHandler<DeleteActivitiesCommand, Unit>
    {

        private readonly IActivitiesRepository _activitiesRepository;
        private readonly IDataProtector _protector;

        public DeleteActivitiesHandler(IActivitiesRepository activitiesRepository, IDataProtectionProvider provider)
        {
            _activitiesRepository = activitiesRepository;
            _protector = provider.CreateProtector("Vinayak");
        }

        public async Task<Unit> Handle(DeleteActivitiesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var campsiteToDelete = await _activitiesRepository.GetByIdAsync(Guid.Parse(request.Id));

                if (campsiteToDelete == null)
                {
                    throw new NotFoundException(nameof(Campsite), Guid.Parse(request.Id));
                }

                //campsiteToDelete.isActive = false;
                //campsiteToDelete.DeletededBy = request.DeletededBy;
                campsiteToDelete.LastModifiedDate = DateTime.UtcNow;

                await _activitiesRepository.DeleteAsync(campsiteToDelete);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw; // Rethrow the exception to maintain consistency in error handling
            }
        }

    }

}

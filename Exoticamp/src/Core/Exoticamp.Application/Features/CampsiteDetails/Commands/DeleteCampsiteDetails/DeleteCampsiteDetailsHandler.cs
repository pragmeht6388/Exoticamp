using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.Campsite.Commands.DeleteCampsite;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CampsiteDetails.Commands.DeleteCampsiteDetails
{
    public class DeleteCampsiteDetailsHandler  : IRequestHandler<DeleteCampsiteDetailsCommand, Unit>
    {
        
            private readonly ICampsiteDetailsRepository _campsiteRepository;
            private readonly IDataProtector _protector;

            public DeleteCampsiteDetailsHandler(ICampsiteDetailsRepository campsiteRepository, IDataProtectionProvider provider)
            {
                _campsiteRepository = campsiteRepository;
                _protector = provider.CreateProtector("Vinayak");
            }

            public async Task<Unit> Handle(DeleteCampsiteDetailsCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var campsiteToDelete = await _campsiteRepository.GetByIdAsync(Guid.Parse(request.Id));

                    if (campsiteToDelete == null)
                    {
                        throw new NotFoundException(nameof(Campsite), Guid.Parse(request.Id));
                    }

                    campsiteToDelete.isActive = false;
                    //campsiteToDelete.DeletededBy = request.DeletededBy;
                    campsiteToDelete.DeletedDate = DateTime.UtcNow;

                    await _campsiteRepository.UpdateAsync(campsiteToDelete);

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


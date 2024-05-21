﻿using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using Exoticamp.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Categories.Commands.UpdateCategory
{
    internal class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Response<UpdateCategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;

        public UpdateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<UpdateCategoryDto>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToUpdate = await _categoryRepository.GetByIdAsync(request.CategoryId);

            if (categoryToUpdate == null)
            {
                throw new NotFoundException(nameof(Category), request.CategoryId);
            }

            var validator = new UpdateCategoryCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, categoryToUpdate);

            await _categoryRepository.UpdateAsync(categoryToUpdate);
            UpdateCategoryDto dto = new UpdateCategoryDto()
            {
                CategoryId = request.CategoryId,
                Name = request.Name,
            };
            return new Response<UpdateCategoryDto>(dto, "Updated successfully ");

        }


    }
}

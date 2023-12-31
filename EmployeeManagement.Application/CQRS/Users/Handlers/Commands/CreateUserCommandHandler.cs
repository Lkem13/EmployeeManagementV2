﻿using AutoMapper;
using EmployeeManagement.Application.CQRS.Users.Requests.Commands;
using EmployeeManagement.Application.DataTransferObject.Location.Validators;
using EmployeeManagement.Application.DataTransferObject.User.Validators;
using EmployeeManagement.Application.Exceptions;
using EmployeeManagement.Application.Contracts.Persistence;
using EmployeeManagement.Application.Responses;
using EmployeeManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.CQRS.Users.Handlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateUserDTOValidator(_unitOfWork.LocationRepository, _unitOfWork.PositionRepository);
            var validationResult = await validator.ValidateAsync(request.UserDTO);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creating Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var user = _mapper.Map<User>(request.UserDTO);
                user = await _unitOfWork.UserRepository.AddAsync(user);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = user.Id;
            }
            
            return response;
        }
    }
}

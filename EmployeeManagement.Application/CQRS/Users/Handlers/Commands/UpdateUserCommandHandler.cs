using AutoMapper;
using EmployeeManagement.Application.CQRS.Users.Requests.Commands;
using EmployeeManagement.Application.DataTransferObject.User.Validators;
using EmployeeManagement.Application.Exceptions;
using EmployeeManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.CQRS.Users.Handlers.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(request.Id);
            if(user is null)
            {
                throw new NotFoundException(nameof(user), request.Id);
            }

            if(request.UserDTO != null)
            {
                var validator = new UpdateUserDTOValidator(_unitOfWork.LocationRepository, _unitOfWork.PositionRepository);
                var validationResult = await validator.ValidateAsync(request.UserDTO);
                if (validationResult.IsValid == false)
                {
                    throw new ValidationException(validationResult);
                }

                _mapper.Map(request.UserDTO, user);
                await _unitOfWork.UserRepository.UpdateAsync(user);
                await _unitOfWork.Save();
            }

            return Unit.Value;
        }
    }
}

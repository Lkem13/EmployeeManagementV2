using AutoMapper;
using EmployeeManagement.Application.CQRS.Users.Requests.Commands;
using EmployeeManagement.Application.DataTransferObject.User.Validators;
using EmployeeManagement.Application.Exceptions;
using EmployeeManagement.Application.Persistence.Repository;
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
        private readonly IUserRepository _userRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, ILocationRepository locationRepository, IPositionRepository positionRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _locationRepository = locationRepository;
            _positionRepository = positionRepository;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateUserDTOValidator(_locationRepository, _positionRepository);
            var validationResult = await validator.ValidateAsync(request.UserDTO);

            if (validationResult.IsValid == false)
            {
                throw new ValidationException(validationResult);
            }

            var user = await _userRepository.GetAsync(request.UserDTO.Id);

            if(request.UserDTO != null)
            {
                _mapper.Map(request.UserDTO, user);

                await _userRepository.UpdateAsync(user);
            }

            return Unit.Value;
        }
    }
}

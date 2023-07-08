using AutoMapper;
using EmployeeManagement.Application.CQRS.Users.Requests.Commands;
using EmployeeManagement.Application.DataTransferObject.Location.Validators;
using EmployeeManagement.Application.DataTransferObject.User.Validators;
using EmployeeManagement.Application.Persistence.Repository;
using EmployeeManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.CQRS.Users.Handlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPositionRepository _positionRepository;
        private readonly ILocationRepository _locationRepository;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IPositionRepository positionRepository, ILocationRepository locationRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _positionRepository = positionRepository;
            _locationRepository = locationRepository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserDTOValidator(_locationRepository, _positionRepository);
            var validationResult = await validator.ValidateAsync(request.UserDTO);

            if (validationResult.IsValid == false)
            {
                throw new Exception();
            }

            var user = _mapper.Map<User>(request.UserDTO);

            user = await _userRepository.AddAsync(user);

            return user.Id;
        }
    }
}

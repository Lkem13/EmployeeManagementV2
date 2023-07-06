using AutoMapper;
using EmployeeManagement.Application.CQRS.Users.Requests.Commands;
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

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.UserDTO);

            user = await _userRepository.AddAsync(user);

            return user.Id;
        }
    }
}

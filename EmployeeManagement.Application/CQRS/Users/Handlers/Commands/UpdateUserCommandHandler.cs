using AutoMapper;
using EmployeeManagement.Application.CQRS.Users.Requests.Commands;
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
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.UserDTO.Id);

            _mapper.Map(request.UserDTO, user);

            await _userRepository.UpdateAsync(user);

            return Unit.Value;
        }
    }
}

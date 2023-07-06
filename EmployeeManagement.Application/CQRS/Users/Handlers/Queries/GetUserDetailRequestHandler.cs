using AutoMapper;
using EmployeeManagement.Application.Persistence.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmployeeManagement.Application.CQRS.Users.Requests.Queries;
using EmployeeManagement.Application.DataTransferObject.User;

namespace EmployeeManagement.Application.CQRS.Users.Handlers.Queries
{
    public class GetUserDetailRequestHandler : IRequestHandler<GetUserDetailRequest, UserDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserDetailRequestHandler(IUserRepository userRepository , IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserDetailRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserWithDetails(request.Id);
            return _mapper.Map<UserDTO>(user);
        }
    }
}

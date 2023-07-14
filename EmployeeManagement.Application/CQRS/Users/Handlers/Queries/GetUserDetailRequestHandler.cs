using AutoMapper;
using EmployeeManagement.Application.Contracts.Persistence;
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
        private readonly IPositionRepository _positionRepository;
        private readonly ILocationRepository _locationRepository;

        public GetUserDetailRequestHandler(IUserRepository userRepository , IMapper mapper, ILocationRepository locationRepository, IPositionRepository positionRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _locationRepository = locationRepository;
            _positionRepository = positionRepository;
        }

        public async Task<UserDTO> Handle(GetUserDetailRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserWithDetails(request.Id);
            return _mapper.Map<UserDTO>(user);
        }
    }
}

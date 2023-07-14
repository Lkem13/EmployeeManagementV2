using AutoMapper;
using EmployeeManagement.Application.Contracts.Persistence;
using EmployeeManagement.Application.CQRS.Users.Requests.Queries;
using EmployeeManagement.Application.DataTransferObject.User;
using EmployeeManagement.Domain;
using MediatR;


namespace EmployeeManagement.Application.CQRS.Users.Handlers.Queries
{
    public class GetUserListRequestHandler : IRequestHandler<GetUserListRequest, List<UserListDTO>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserListRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserListDTO>> Handle(GetUserListRequest request, CancellationToken cancellationToken)
        {
            var users = new List<User>();
            var requests = new List<UserListDTO>();

            users = await _userRepository.GetUsersWithDetails();
            requests = _mapper.Map<List<UserListDTO>>(users);

            return requests;
        }
    }
}

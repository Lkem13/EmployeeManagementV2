using AutoMapper;
using EmployeeManagement.MVC.Contracts;
using EmployeeManagement.MVC.Models;
using EmployeeManagement.MVC.Services.Base;

namespace EmployeeManagement.MVC.Services
{
    public class UserService : BaseHttpService, IUserService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpclient;

        public UserService(IMapper mapper, IClient httpclient, ILocalStorageService localStorageService) : base(httpclient, localStorageService)
        {
            this._localStorageService = localStorageService;
            this._mapper = mapper;
            this._httpclient = httpclient;
        }

        public async Task<Response<int>> CreateEmployee(CreateEmployeeVM employee)
        {
            try
            {
                var response = new Response<int>();
                CreateUserDTO createUser = _mapper.Map<CreateUserDTO>(employee);
                AddBearerToken();
                var apiResponse = await _client.UsersPOSTAsync(createUser);
                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach (var error in apiResponse.Errors)
                    {
                        response.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<AdminEmployeeViewVM> GetAdminUserList()
        {
            AddBearerToken();
            var employees = await _client.UsersAllAsync();

            var model = new AdminEmployeeViewVM
            {
                Employees = _mapper.Map<List<EmployeeVM>>(employees)
        };
        return model;
        }

        public async Task<EmployeeVM> GetEmployeeDetails(int id)
        {
            AddBearerToken();
            var user = await _client.UsersGETAsync(id);
            return _mapper.Map<EmployeeVM>(user);
        }

        public async Task<List<EmployeeVM>> GetEmployees()
        {
            AddBearerToken();
            var users = await _client.UsersAllAsync();
            return _mapper.Map<List<EmployeeVM>>(users);
        }

        public async Task<Response<int>> DeleteEmployee(int id)
        {
            try
            {
                AddBearerToken();
                await _client.UsersDELETEAsync(id);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}

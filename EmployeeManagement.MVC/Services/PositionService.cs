using AutoMapper;
using EmployeeManagement.MVC.Contracts;
using EmployeeManagement.MVC.Models;
using EmployeeManagement.MVC.Services.Base;

namespace EmployeeManagement.MVC.Services
{
    public class PositionService : BaseHttpService, IPositionService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;

        public PositionService(IMapper mapper, IClient httpClient, ILocalStorageService localStorageService) : base(httpClient, localStorageService)
        {
            _localStorageService = localStorageService;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task<Response<int>> CreatePosition(CreatePositionVM position)
        {
            try
            {
                var response = new Response<int>();
                CreatePositionDTO createPosition = _mapper.Map<CreatePositionDTO>(position);
                AddBearerToken();
                var apiResponse = await _client.PositionsPOSTAsync(createPosition);
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

        public async Task<Response<int>> DeletePosition(int id)
        {
            try
            {
                AddBearerToken();
                await _client.PositionsDELETEAsync(id);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<PositionVM> GetPositionDetails(int id)
        {
            AddBearerToken();
            var position = await _client.PositionsGETAsync(id);
            return _mapper.Map<PositionVM>(position);
        }

        public async Task<List<PositionVM>> GetPositions()
        {
            AddBearerToken();
            var positions = await _client.PositionsAllAsync();
            return _mapper.Map<List<PositionVM>>(positions);
        }

        public async Task<Response<int>> UpdatePosition(int id, PositionVM position)
        {
            try
            {
                PositionDTO positionDTO = _mapper.Map<PositionDTO>(position);
                AddBearerToken();
                await _client.PositionsPUTAsync(id, positionDTO);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}

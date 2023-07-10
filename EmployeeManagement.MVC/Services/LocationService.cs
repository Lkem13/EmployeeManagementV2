using AutoMapper;
using EmployeeManagement.MVC.Contracts;
using EmployeeManagement.MVC.Models;
using EmployeeManagement.MVC.Services.Base;

namespace EmployeeManagement.MVC.Services
{
    public class LocationService : BaseHttpService, ILocationService
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly IMapper _mapper;
        private readonly IClient _httpClient;

        public LocationService(IMapper mapper, IClient httpClient, ILocalStorageService localStorageService) : base(httpClient, localStorageService)
        {
            _localStorageService = localStorageService;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task<Response<int>> CreateLocation(CreateLocationVM location)
        {
            try
            {
                var response = new Response<int>();
                CreateLocationDTO createLocation = _mapper.Map<CreateLocationDTO>(location);
                AddBearerToken();
                var apiResponse = await _client.LocationsPOSTAsync(createLocation);
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

        public async Task<Response<int>> DeleteLocation(int id)
        {
            try
            {
                AddBearerToken();
                await _client.LocationsDELETEAsync(id);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<LocationVM> GetLocationDetails(int id)
        {
            AddBearerToken();
            var location = await _client.LocationsGETAsync(id);
            return _mapper.Map<LocationVM>(location);
        }

        public async Task<List<LocationVM>> GetLocations()
        {
            AddBearerToken();
            var locations = await _client.LocationsAllAsync();
            return _mapper.Map<List<LocationVM>>(locations);
        }

        public async Task<Response<int>> UpdateLocation(int id, LocationVM location)
        {
            try
            {
                LocationDTO locationDTO = _mapper.Map<LocationDTO>(location);
                AddBearerToken();
                await _client.LocationsPUTAsync(id, locationDTO);
                return new Response<int>() { Success = true };
            }
            catch (ApiException ex) 
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}

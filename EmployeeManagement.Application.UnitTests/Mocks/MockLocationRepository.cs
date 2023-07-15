using EmployeeManagement.Application.Contracts.Persistence;
using EmployeeManagement.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.UnitTests.Mocks
{
    public static class MockLocationRepository
    {
        public static Mock<ILocationRepository> GetLocationRepository()
        {
            var locations = new List<Location>
             {
                  new Location
                  {
                      Id = 1,
                      Town = "Test Krakow",
                      Street = "Test 13"
                  },
                  new Location
                  {
                      Id = 2,
                      Town = "Test Warszawa",
                      Street = "Test 5"
                  },
                  new Location
                  {
                      Id = 3,
                      Town = "Test Katowice",
                      Street = "Test 11"
                  }
             };

            var mockRepo = new Mock<ILocationRepository>();

            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(locations);

            mockRepo.Setup(r => r.AddAsync(It.IsAny<Location>())).ReturnsAsync((Location location) =>
            {
                locations.Add(location);
                return location;
            });
            return mockRepo;
        }
    }
}

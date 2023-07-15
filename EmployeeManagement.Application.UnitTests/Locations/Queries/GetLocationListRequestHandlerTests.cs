using AutoMapper;
using EmployeeManagement.Application.Contracts.Persistence;
using EmployeeManagement.Application.CQRS.Locations.Handlers.Queries;
using EmployeeManagement.Application.CQRS.Locations.Requests.Queries;
using EmployeeManagement.Application.CQRS.Positions.Handlers.Queries;
using EmployeeManagement.Application.CQRS.Positions.Requests.Queries;
using EmployeeManagement.Application.DataTransferObject.Location;
using EmployeeManagement.Application.DataTransferObject.Position;
using EmployeeManagement.Application.Profiles;
using EmployeeManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagement.Application.UnitTests.Locations.Queries
{
    public class GetLocationListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILocationRepository> _mockRepo;

        public GetLocationListRequestHandlerTests()
        {
            _mockRepo = MockLocationRepository.GetLocationRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetLocationListTest()
        {
            var handler = new GetLocationListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetLocationListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<LocationDTO>>();

            result.Count.ShouldBe(3);
        }
    }
}

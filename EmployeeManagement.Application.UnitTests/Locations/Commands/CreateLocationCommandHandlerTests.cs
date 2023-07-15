using AutoMapper;
using Moq;
using EmployeeManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Application.DataTransferObject.Position;
using EmployeeManagement.Application.CQRS.Positions.Handlers.Commands;
using EmployeeManagement.Application.UnitTests.Mocks;
using EmployeeManagement.Application.Profiles;
using Xunit;
using EmployeeManagement.Application.CQRS.Positions.Requests.Commands;
using Shouldly;
using EmployeeManagement.Application.Responses;
using EmployeeManagement.Application.DataTransferObject.Location;
using EmployeeManagement.Application.CQRS.Locations.Handlers.Commands;
using EmployeeManagement.Application.CQRS.Locations.Requests.Commands;

namespace EmployeeManagement.Application.UnitTests.Locations.Commands
{
    public class CreateLocationCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILocationRepository> _mockRepo;
        private readonly CreateLocationDTO _locationDTO;
        private readonly CreateLocationCommandHandler _handler;

        public CreateLocationCommandHandlerTests()
        {
            _mockRepo = MockLocationRepository.GetLocationRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreateLocationCommandHandler(_mockRepo.Object, _mapper);

            _locationDTO = new CreateLocationDTO
            {
                Town = "Test DTO",
                Street = "DTO Test"
            };
        }

        [Fact]
        public async Task Valid_Location_Added()
        {
            var result = await _handler.Handle(new CreateLocationCommand() { LocationDTO = _locationDTO}, CancellationToken.None);

            var locations = await _mockRepo.Object.GetAllAsync();

            result.ShouldBeOfType<BaseCommandResponse>();

            locations.Count.ShouldBe(4);
            ;
        }


    }
}

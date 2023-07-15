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

namespace EmployeeManagement.Application.UnitTests.Positions.Commands
{
    public class CreatePositionCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPositionRepository> _mockRepo;
        private readonly CreatePositionDTO _positionDTO;
        private readonly CreatePositionCommandHandler _handler;

        public CreatePositionCommandHandlerTests()
        {
            _mockRepo = MockPositionRepository.GetPositionRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _handler = new CreatePositionCommandHandler(_mockRepo.Object, _mapper);

            _positionDTO = new CreatePositionDTO
            {
                Name = "Test DTO"
            };
        }

        [Fact]
        public async Task Valid_Position_Added()
        {
            var result = await _handler.Handle(new CreatePositionCommand() { PositionDTO = _positionDTO }, CancellationToken.None);

            var positions = await _mockRepo.Object.GetAllAsync();

            result.ShouldBeOfType<BaseCommandResponse>();

            positions.Count.ShouldBe(4);
;        }


    }
}

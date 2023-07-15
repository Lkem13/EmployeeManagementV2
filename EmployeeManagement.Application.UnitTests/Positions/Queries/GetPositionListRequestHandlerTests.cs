using AutoMapper;
using EmployeeManagement.Application.Contracts.Persistence;
using EmployeeManagement.Application.CQRS.Positions.Handlers.Queries;
using EmployeeManagement.Application.CQRS.Positions.Requests.Queries;
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

namespace EmployeeManagement.Application.UnitTests.Positions.Queries
{
    public class GetPositionListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IPositionRepository> _mockRepo;

        public GetPositionListRequestHandlerTests()
        {
            _mockRepo = MockPositionRepository.GetPositionRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetPositionListTest()
        {
            var handler = new GetPositionListRequestHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetPositionListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<PositionDTO>>();

            result.Count.ShouldBe(3);
        }
    }
}

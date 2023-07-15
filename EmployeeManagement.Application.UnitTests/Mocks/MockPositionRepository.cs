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
    public static class MockPositionRepository
    {
        public static Mock<IPositionRepository> GetPositionRepository()
        {
            var positions = new List<Position>
             {
                  new Position
                  {
                      Id = 1,
                      Name = "Test IT Support"
                  },
                  new Position
                  {
                      Id = 2,
                      Name = "Test HR"
                  },
                  new Position
                  {
                      Id = 3,
                      Name = "Test Financial"
                  }
             };

            var mockRepo = new Mock<IPositionRepository>();

            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(positions);

            mockRepo.Setup(r => r.AddAsync(It.IsAny<Position>())).ReturnsAsync((Position position) =>
            {
                positions.Add(position);
                return position;
            });
            return mockRepo;
        }
    }
}

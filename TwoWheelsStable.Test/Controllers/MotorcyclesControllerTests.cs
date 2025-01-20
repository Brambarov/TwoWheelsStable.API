using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using TwoWheelsStable.API.Controllers;
using TwoWheelsStable.API.DTOs.Motorcycle;
using TwoWheelsStable.API.Helpers.Queries;
using TwoWheelsStable.API.Services.Contracts;

namespace TwoWheelsStable.Test.Controllers
{
    public class MotorcyclesControllerTests
    {
        private readonly Random random = new();

        [Fact]
        public async Task GetAll_Returns_OkResult_With_AllMotorcycles()
        {
            // Arrange
            var expectedCount = random.Next(1, 100);
            var motorcycleDTOs = A.CollectionOfDummy<MotorcycleGetDTO>(expectedCount).AsEnumerable();

            var urlHelperFactory = A.Fake<IUrlHelperFactory>();
            var motorcyclesService = A.Fake<IMotorcyclesService>();
            var commentsService = A.Fake<ICommentsService>();
            var jobsService = A.Fake<IJobsService>();

            A.CallTo(() => motorcyclesService.GetAllAsync(A<MotorcycleQuery>._, A<IUrlHelper>._)).Returns(motorcycleDTOs);

            var motorcyclesController = new MotorcyclesController(motorcyclesService,
                                                                  commentsService,
                                                                  jobsService,
                                                                  urlHelperFactory);

            // Act
            var actionResult = await motorcyclesController.GetAll(new MotorcycleQuery());

            // Assert
            var result = Assert.IsType<OkObjectResult>(actionResult);
            var motorcycles = Assert.IsType<List<MotorcycleGetDTO>>(result.Value);

            Assert.NotNull(motorcycles);
            Assert.Equal(expectedCount, motorcycles.Count);
        }

        [Fact]
        public async Task GetById_Returns_OkResult_With_Motorcycle()
        {
            // Arrange
            var motorcycleDTO = A.Fake<MotorcycleGetDTO>();

            var urlHelperFactory = A.Fake<IUrlHelperFactory>();
            var motorcyclesService = A.Fake<IMotorcyclesService>();
            var commentsService = A.Fake<ICommentsService>();
            var jobsService = A.Fake<IJobsService>();

            A.CallTo(() => motorcyclesService.GetByIdAsync(A<Guid>._, A<IUrlHelper>._)).Returns(motorcycleDTO);

            var motorcyclesController = new MotorcyclesController(motorcyclesService,
                                                                  commentsService,
                                                                  jobsService,
                                                                  urlHelperFactory);

            // Act
            var actionResult = await motorcyclesController.GetById(Guid.NewGuid());

            // Assert
            var result = Assert.IsType<OkObjectResult>(actionResult);
            var motorcycle = Assert.IsType<MotorcycleGetDTO>(result.Value);

            Assert.NotNull(motorcycle);
        }
    }
}

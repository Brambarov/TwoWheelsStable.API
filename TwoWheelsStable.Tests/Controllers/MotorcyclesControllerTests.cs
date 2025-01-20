using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using TwoWheelsStable.API.Controllers;
using TwoWheelsStable.API.DTOs.Motorcycle;
using TwoWheelsStable.API.Helpers.Queries;
using TwoWheelsStable.API.Services.Contracts;
namespace TwoWheelsStable.Tests.Controllers
{
    public class MotorcyclesControllerTests
    {
        [Fact]
        public async Task GetAll_Returns_OkResult_With_CorrectNumberOfMotorcycles()
        {
            // Arrange
            var expectedCount = 3;
            var motorcycleDTOs = A.CollectionOfDummy<MotorcycleGetDTO>(expectedCount).AsEnumerable();

            var urlHelperFactory = A.Fake<IUrlHelperFactory>();
            var motorcyclesService = A.Fake<IMotorcyclesService>();
            var commentsService = A.Fake<ICommentsService>();
            var jobsService = A.Fake<IJobsService>();

            A.CallTo(() => motorcyclesService.GetAllAsync(A<MotorcycleQuery>._, A<IUrlHelper>._)).ReturnsLazily(() => Task.FromResult(motorcycleDTOs));

            var motorcyclesController = new MotorcyclesController(motorcyclesService,
                                                                  commentsService,
                                                                  jobsService,
                                                                  urlHelperFactory);

            // Act
            var actionResult = await motorcyclesController.GetAll(null);

            // Assert
            var result = Assert.IsType<OkObjectResult>(actionResult);
            var motorcycles = Assert.IsType<IEnumerable<MotorcycleGetDTO>>(result.Value, false);

            Assert.NotNull(motorcycles);
            Assert.Equal(expectedCount, motorcycles.Count());
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Moq;
using TwoWheelsStable.API.Helpers.Queries;

namespace TwoWheelsStable.Test.Controllers.Motorcycles
{
    public class GetAll_Tests : MotorcyclesController_Tests_Base
    {
        [Fact]
        public async Task GetAll_Returns_200_When_ModelState_Is_Valid()
        {
            // Arrange
            var expectedMotorcycleGetDTOs = GenerateMotorcycleGetDTOs(2, 20);

            _mockMotorcyclesService.Setup(s => s.GetAllAsync(It.IsAny<MotorcycleQuery>(), It.IsAny<IUrlHelper>())).ReturnsAsync(expectedMotorcycleGetDTOs);

            // Act
            var result = await _motorcyclesController.GetAll(It.IsAny<MotorcycleQuery>()) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expectedMotorcycleGetDTOs, result.Value);
        }

        [Fact]
        public async Task GetAll_Returns_400_When_ModelState_Is_Invalid()
        {
            // Arrange
            var key = "key";
            var errorMessage = "errorMessage";

            _motorcyclesController.ModelState.AddModelError(key, errorMessage);
            // Act
            var result = await _motorcyclesController.GetAll(It.IsAny<MotorcycleQuery>()) as BadRequestObjectResult;

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);

            var errors = result.Value as SerializableError;
            Assert.NotNull(errors);

            var errorMessages = errors[key] as string[];
            Assert.NotNull(errorMessages);
            Assert.Contains(errorMessage, errorMessages);
        }
    }
}

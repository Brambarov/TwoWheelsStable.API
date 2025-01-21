using Microsoft.AspNetCore.Mvc;
using Moq;
using TwoWheelsStable.API.DTOs.Motorcycle;

namespace TwoWheelsStable.Test.Controllers.Motorcycles
{
    public class GetById_Tests : MotorcyclesController_Tests_Base
    {
        [Fact]
        public async Task GetById_Returns_200_When_MotorcycleExists()
        {
            // Arrange
            var motorcycleId = Guid.NewGuid();

            var expectedMotorcycleGetDTO = GenerateMotorcycleGetDTO(motorcycleId);

            _mockMotorcyclesService.Setup(s => s.GetByIdAsync(motorcycleId, It.IsAny<IUrlHelper>()))
                                   .ReturnsAsync(expectedMotorcycleGetDTO);

            // Act
            var result = await _motorcyclesController.GetById(motorcycleId) as ObjectResult;

            // Assert
            _mockMotorcyclesService.Verify(s => s.GetByIdAsync(motorcycleId, It.IsAny<IUrlHelper>()), Times.Once);

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expectedMotorcycleGetDTO, result.Value);
        }

        [Fact]
        public async Task GetById_Returns_404_When_MotorcycleDoesNotExist()
        {
            // Arrange
            var motorcycleId = Guid.NewGuid();

            _mockMotorcyclesService.Setup(s => s.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<IUrlHelper>())).ReturnsAsync(null as MotorcycleGetDTO);

            // Act
            var result = await _motorcyclesController.GetById(motorcycleId) as StatusCodeResult;

            // Assert
            _mockMotorcyclesService.Verify(s => s.GetByIdAsync(motorcycleId, It.IsAny<IUrlHelper>()), Times.Once);

            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
        }
    }
}

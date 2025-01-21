using Microsoft.AspNetCore.Mvc;
using Moq;
using TwoWheelsStable.API.DTOs.Motorcycle;

namespace TwoWheelsStable.Test.Controllers.Motorcycles
{
    public class Create_Tests : MotorcyclesController_Tests_Base
    {
        [Fact]
        public async Task Create_Returns_200_With_ExpectedMotorcycleDTO()
        {
            // Arrange
            var motorcyclePostDTO = new MotorcyclePostDTO
            {
                Name = "Motorcycle",
                Make = "Make",
                Model = "Model",
                Year = 2000,
                Mileage = 1000
            };

            var expectedMotorcycleGetDTO = new MotorcycleGetDTO
            {
                Name = motorcyclePostDTO.Name,
                Make = motorcyclePostDTO.Make,
                Model = motorcyclePostDTO.Model,
                Year = motorcyclePostDTO.Year,
                Mileage = motorcyclePostDTO.Mileage
            };

            _mockMotorcyclesService.Setup(s => s.CreateAsync(motorcyclePostDTO, It.IsAny<IUrlHelper>())).ReturnsAsync(expectedMotorcycleGetDTO);

            // Act
            var result = await _motorcyclesController.Create(motorcyclePostDTO) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expectedMotorcycleGetDTO, result.Value);
        }
    }
}

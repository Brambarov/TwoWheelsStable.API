using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Moq;
using TwoWheelsStable.API.Controllers;
using TwoWheelsStable.API.DTOs.Motorcycle;
using TwoWheelsStable.API.Helpers.Queries;
using TwoWheelsStable.API.Services.Contracts;

namespace TwoWheelsStable.Test.Controllers
{
    public class MotorcyclesControllerTests
    {
        private readonly Mock<IMotorcyclesService> _mockMotorcyclesService;
        private readonly Mock<ICommentsService> _mockCommentsService;
        private readonly Mock<IJobsService> _mockJobsService;
        private readonly Mock<IUrlHelperFactory> _mockUrlHelperFactory;
        private readonly MotorcyclesController _motorcyclesController;

        private readonly Random random = new();

        public MotorcyclesControllerTests()
        {
            _mockMotorcyclesService = new Mock<IMotorcyclesService>();
            _mockCommentsService = new Mock<ICommentsService>();
            _mockJobsService = new Mock<IJobsService>();
            _mockUrlHelperFactory = new Mock<IUrlHelperFactory>();
            _motorcyclesController = new MotorcyclesController(_mockMotorcyclesService.Object,
                                                               _mockCommentsService.Object,
                                                               _mockJobsService.Object,
                                                               _mockUrlHelperFactory.Object);
        }

        [Fact]
        public async Task GetAll_Returns_200_With_ExpectedMotorcycleDTOs()
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
        public async Task GetById_Returns_200_With_ExpectedMotorcycleDTO()
        {
            // Arrange
            var motorcycleId = Guid.NewGuid();

            var expectedMotorcycleGetDTO = GenerateMotorcycleGetDTO(motorcycleId);

            _mockMotorcyclesService.Setup(s => s.GetByIdAsync(motorcycleId, It.IsAny<IUrlHelper>())).ReturnsAsync(expectedMotorcycleGetDTO);

            // Act
            var result = await _motorcyclesController.GetById(motorcycleId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expectedMotorcycleGetDTO, result.Value);
        }

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

        private List<MotorcycleGetDTO> GenerateMotorcycleGetDTOs(int minValue, int maxValue)
        {
            int count = random.Next(minValue, maxValue);

            var expectedMotorcycleDTOs = new List<MotorcycleGetDTO>();
            for (int i = 0; i < count; i++)
            {
                expectedMotorcycleDTOs.Add(new MotorcycleGetDTO
                {
                    Href = $"mock/motorcycles/{i}",
                    Name = $"Motorcycle{i}",
                    Make = $"Make{i}",
                    Model = $"Model{i}",
                    Year = 2000 + i,
                    Mileage = 1000 * i
                });
            };

            return expectedMotorcycleDTOs;
        }

        private MotorcycleGetDTO GenerateMotorcycleGetDTO(Guid id)
        {
            return new MotorcycleGetDTO
            {
                Href = $"mock/motorcycles/{id}",
                Name = $"Motorcycle{id}",
                Make = $"Make{id}",
                Model = $"Model{id}",
                Year = 2000,
                Mileage = 1000
            };
        }
    }
}

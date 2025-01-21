using Microsoft.AspNetCore.Mvc.Routing;
using Moq;
using TwoWheelsStable.API.Controllers;
using TwoWheelsStable.API.DTOs.Motorcycle;
using TwoWheelsStable.API.Services.Contracts;

namespace TwoWheelsStable.Test.Controllers.Motorcycles
{
    public abstract class MotorcyclesController_Tests_Base
    {
        protected readonly Mock<IMotorcyclesService> _mockMotorcyclesService;
        protected readonly Mock<ICommentsService> _mockCommentsService;
        protected readonly Mock<IJobsService> _mockJobsService;
        protected readonly Mock<IUrlHelperFactory> _mockUrlHelperFactory;
        protected readonly MotorcyclesController _motorcyclesController;

        protected readonly Random random = new();

        protected MotorcyclesController_Tests_Base()
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

        protected List<MotorcycleGetDTO> GenerateMotorcycleGetDTOs(int minValue, int maxValue)
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

        protected static MotorcycleGetDTO GenerateMotorcycleGetDTO(Guid id)
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

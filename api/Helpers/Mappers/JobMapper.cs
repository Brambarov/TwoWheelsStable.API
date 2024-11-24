using api.DTOs.Job;
using api.Models;

namespace api.Helpers.Mappers
{
    public static class JobMapper
    {
        public static JobGetDTO ToGetDTO(this Job model)
        {
            return new JobGetDTO
            {
                Title = model.Title,
                Description = model.Description,
                Cost = model.Cost,
                Date = model.Date,
                DueDate = model.DueDate,
                Mileage = model.Mileage,
                DueMileage = model.DueMileage
            };
        }

        public static Job FromPostDTO(this JobPostDTO dto, string userId, int? motorcycleId)
        {
            return new Job
            {
                Title = dto.Title,
                Description = dto.Description,
                Cost = dto.Cost,
                Date = dto.Date,
                DueDate = dto.DueDate,
                Mileage = dto.Mileage,
                DueMileage = dto.DueMileage,
                UserId = userId,
                MotorcycleId = motorcycleId
            };
        }

        public static Job FromPutDTO(this JobPutDTO dto, Job model)
        {
            model.Title = dto.Title;
            model.Description = dto.Description;
            model.Cost = dto.Cost;
            model.Date = dto.Date;
            model.DueDate = dto.DueDate;
            model.Mileage = dto.Mileage;
            model.DueMileage = dto.DueMileage;

            return model;
        }
    }
}

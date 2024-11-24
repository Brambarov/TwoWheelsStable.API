using api.DTOs.Motorcycle;
using api.Models;

namespace api.Helpers.Mappers
{
    public static class MotorcycleMapper
    {
        public static MotorcycleGetDTO ToGetDTO(this Motorcycle model)
        {
            return new MotorcycleGetDTO
            {
                Name = model.Name,
                Make = model.Make,
                Model = model.Model,
                Year = model.Year,
                Mileage = model.Mileage,
                Specs = model.Specs?.ToGetDTO(),
                Owner = model.User?.UserName,
                Schedule = model.Schedule.Select(j => j.ToGetDTO()).ToList(),
                Comments = model.Comments.Select(c => c.ToGetDTO()).ToList()
            };
        }

        public static Motorcycle FromPostDTO(this MotorcyclePostDTO dto, int? specsId, string userId)
        {
            return new Motorcycle
            {
                Name = dto.Name,
                Make = dto.Make,
                Model = dto.Model,
                Year = dto.Year,
                Mileage = dto.Mileage,
                SpecsId = specsId,
                UserId = userId
            };
        }

        public static Motorcycle FromPutDTO(this MotorcyclePutDTO dto, Motorcycle model, int? specsId)
        {
            model.Name = dto.Name;
            model.Make = dto.Make;
            model.Model = dto.Model;
            model.Year = dto.Year;
            model.Mileage = dto.Mileage;
            model.SpecsId = specsId;

            return model;
        }
    }
}

using api.DTOs.Motorcycle;
using api.Models;
using Newtonsoft.Json;

namespace api.Helpers.Mappers
{
    public static class MotorcycleMapper
    {
        public static MotorcycleGetDTO ToGetDTO(this Motorcycle model, string? techSpecs)
        {
            return new MotorcycleGetDTO
            {
                Name = model.Name,
                Make = model.Make,
                Model = model.Model,
                TechnicalSpecification = techSpecs,
                Comments = model.Comments.Select(c => c.ToGetDTO()).ToList()
            };
        }

        public static Motorcycle FromPostDTO(this MotorcyclePostDTO dto)
        {
            return new Motorcycle
            {
                Name = dto.Name,
                Make = dto.Make,
                Model = dto.Model
            };
        }

        public static Motorcycle FromPutDTO(this MotorcyclePutDTO dto, int id)
        {
            return new Motorcycle
            {
                Id = id,
                Name = dto.Name,
                Make = dto.Make,
                Model = dto.Model
            };
        }
    }
}

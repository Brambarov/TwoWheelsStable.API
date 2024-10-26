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

        public static Motorcycle FromPutDTO(this Motorcycle model, int id, MotorcyclePutDTO dto)
        {
            model.Id = id;
            model.Name = dto.Name;
            model.Make = dto.Make;
            model.Model = dto.Model;

            return model;
        }
    }
}

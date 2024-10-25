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
                Make = model.Make,
                Model = model.Model
            };
        }

        public static Motorcycle FromPostDTO(this MotorcyclePostDTO dto)
        {
            return new Motorcycle
            {
                Make = dto.Make,
                Model = dto.Model
            };
        }

        public static void FromPutDTO(this Motorcycle model, MotorcyclePutDTO dto)
        {
            model.Make = dto.Make;
            model.Model = dto.Model;
        }
    }
}

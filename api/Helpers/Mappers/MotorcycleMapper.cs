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
                Specs = model.Specs.ToGetDTO(),
                Comments = model.Comments.Select(c => c.ToGetDTO()).ToList()
            };
        }

        public static Motorcycle FromPostDTO(this MotorcyclePostDTO dto, int? specsId)
        {
            return new Motorcycle
            {
                Name = dto.Name,
                Make = dto.Make,
                Model = dto.Model,
                Year = dto.Year,
                SpecsId = specsId
            };
        }

        public static Motorcycle FromPutDTO(this MotorcyclePutDTO dto, int id)
        {
            return new Motorcycle
            {
                Id = id,
                Name = dto.Name,
                Make = dto.Make,
                Model = dto.Model,
                Year = dto.Year
            };
        }
    }
}

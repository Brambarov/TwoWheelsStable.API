using api.DTOs.Motorcycle;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Helpers.Mappers
{
    public static class MotorcycleMapper
    {
        public static MotorcycleGetDTO ToGetDTO(this Motorcycle model, IUrlHelper urlHelper)
        {
            return new MotorcycleGetDTO
            {
                Href = urlHelper.Link("GetMotorcycleById", new { id = model.Id })
                       ?? throw new ArgumentNullException(nameof(urlHelper), "Resource address is null!"),
                Name = model.Name,
                Make = model.Make,
                Model = model.Model,
                Year = model.Year,
                Mileage = model.Mileage,
                Specs = model.Specs?.ToGetDTO(urlHelper),
                Owner = model.User?.UserName,
                Jobs = model.Jobs.Select(j => j.ToGetDTO(urlHelper)).ToList(),
                Comments = model.Comments.Select(c => c.ToGetDTO(urlHelper)).ToList()
            };
        }

        public static Motorcycle FromPostDTO(this MotorcyclePostDTO dto, Guid specsId, string userId)
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

        public static Motorcycle FromPutDTO(this MotorcyclePutDTO dto, Motorcycle model, Guid specsId)
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

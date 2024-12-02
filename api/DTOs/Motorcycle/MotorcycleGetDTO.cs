using api.DTOs.Comment;
using api.DTOs.Image;
using api.DTOs.Job;
using api.DTOs.Specs;

namespace api.DTOs.Motorcycle
{
    public class MotorcycleGetDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public int Mileage { get; set; }
        public SpecsGetDTO? Specs { get; set; }
        public string? Owner { get; set; } = string.Empty;
        public List<ImageGetDTO> Images { get; set; } = [];
        public List<JobGetDTO> Jobs { get; set; } = [];
        public List<CommentGetDTO> Comments { get; set; } = [];
    }
}

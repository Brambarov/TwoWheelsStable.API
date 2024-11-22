using api.DTOs.Comment;
using api.DTOs.Job;
using api.DTOs.Specs;

namespace api.DTOs.Motorcycle
{
    public class MotorcycleGetDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public int Mileage { get; set; }
        public SpecsGetDTO? Specs { get; set; }
        public string? Owner { get; set; } = string.Empty;
        public List<JobGetDTO> Schedule { get; set; } = [];
        public List<CommentGetDTO> Comments { get; set; } = [];
    }
}

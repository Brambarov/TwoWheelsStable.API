namespace api.Models
{
    public class Motorcycle
    {
        public int Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}

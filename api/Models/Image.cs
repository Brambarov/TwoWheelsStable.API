namespace api.Models
{
    public class Image
    {
        public int Id { get; set; }
        public int? MotorcycleId { get; set; }
        public Motorcycle? Motorcycle { get; set; }
        public byte[]? Data { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string MimeType { get; set; } = string.Empty;
    }
}

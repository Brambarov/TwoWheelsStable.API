namespace api.DTOs.Image
{
    public class ImageGetDTO
    {
        public string Href { get; set; } = string.Empty;
        public byte[]? Data { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string MimeType { get; set; } = string.Empty;
    }
}

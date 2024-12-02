﻿namespace api.DTOs.Image
{
    public class ImagePostDTO
    {
        public int? MotorcycleId { get; set; }
        public byte[]? Data { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string MimeType { get; set; } = string.Empty;
    }
}

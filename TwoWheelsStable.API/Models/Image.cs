using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TwoWheelsStable.API.Helpers.Enums;

namespace TwoWheelsStable.API.Models
{
    [Table("Images")]
    public class Image
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ResourceId { get; set; }
        public ResourceType ResourceType { get; set; }
        public byte[]? Data { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string MimeType { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
    }
}

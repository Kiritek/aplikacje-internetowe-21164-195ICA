using System.ComponentModel.DataAnnotations;

namespace RestApiAppv2.Models
{
    public class PostForCreationDto
    {
        [Required]
        public string Title { get; set; }
        [Required]

        public string Description { get; set; }
        [Required]

        public string Category { get; set; }
    }
}

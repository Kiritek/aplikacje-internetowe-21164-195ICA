using System.ComponentModel.DataAnnotations;

namespace RestApiAppv2.Entities
{
    public class Post
    {   [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        [Required]
        [MaxLength(100)]
        public string Category { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        [Required]
        [MaxLength(50)]
        public string AuthorId { get; set; }
    }
}

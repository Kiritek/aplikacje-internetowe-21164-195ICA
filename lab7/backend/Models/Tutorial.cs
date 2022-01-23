using System.ComponentModel.DataAnnotations;

namespace CRUD_API2.Models
{
    public class Tutorial
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        [Required]
        public bool IsPublished { get; set; }
    }
}

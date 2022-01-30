using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Models
{
    public class Todo
    {   [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength (50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        [Required]
        public bool Completed { get; set; } = false;
        [Required]
        public string Priority { get; set; } = "low";

    }
}

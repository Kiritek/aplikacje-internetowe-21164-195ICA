using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ToDoApi.Models
{
    public class TodoForCreationDto: IValidatableObject
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        [Required]
        public bool Completed { get; set; } = false;
        [Required]
        public string Priority { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Title == Description)
            {
                yield return new ValidationResult(
                    "The provided description should be different from the title.",
                    new[] { "TodoTitleDescription" });
            }
            string[] priorities = new string[3]{
            "low","medium","high"
            };
            if (!priorities.Any(p=>p== Priority)){
                yield return new ValidationResult(
                    "Wrong priority", new[] { "Todopriority" });
            }
        }
    }
}

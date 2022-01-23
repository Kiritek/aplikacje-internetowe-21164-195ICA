using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUD_API2.Models
{
    public class TutorialForUpdateDto : IValidatableObject
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(1500)]
        public string Description { get; set; }
        [Required]
        public bool IsPublished { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Title == Description)
            {
                yield return new ValidationResult(
                    "The provided description should be different from the title.",
                    new[] { "TutorialForCreationDto" });
            }
        }
    }
}

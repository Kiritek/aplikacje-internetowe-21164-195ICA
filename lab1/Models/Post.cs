using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Post
    {
        [BindNever]
        public int Id { get; set; }
        public string Author { get; set; }
        [Required(ErrorMessage ="Please enter publish date")]
        public DateTime PostPublishDate { get; set; }
        [Required]
        public bool IsHighlighted { get; set; }
        public DateTime PostDate { get; set; }
        [Required(ErrorMessage ="Please enter short descritpion")]
        public string PostShortDescritpion { get; set; }
        [Required(ErrorMessage ="Please enter long description")]
        public string PostLongDescription { get; set; }
        [Required(ErrorMessage ="Please enter category")]
        public CategoryTag Category { get; set; }
        public int Score { get; set; } = 0;

    }
}

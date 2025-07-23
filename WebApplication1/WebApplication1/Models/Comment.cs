using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "User name is required.")]
        [MaxLength(100, ErrorMessage = "User name cannot exceed 100 characters.")]
        public string UserName { get; set; }

        [DataType(DataType.Date)]
        [ValidateNever]
        public DateTime CommentDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; }
        [ForeignKey("Post")]
        public int postId { get; set; }
        public Post post { get; set; }
    }
}

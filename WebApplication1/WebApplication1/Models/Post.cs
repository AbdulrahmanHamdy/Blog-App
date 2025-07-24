using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="the Title isreqouird")]
        [MaxLength(400, ErrorMessage = "the Title is too long, max 400 characters")]
        public string Title { get; set; }
        [Required(ErrorMessage = "the Contant isreqouird")]

        public string Content { get; set; }
        [Required(ErrorMessage = "the Auther isreqouird")]
        [MaxLength(200, ErrorMessage = "the Auther is too long, max 200 characters")]
        public string Author { get; set; }

        public string FeatureImagePath { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime PublishDate { get; set; } = DateTime.Now;
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category categor { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}

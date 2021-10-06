using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Comment : BaseModel
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(800)]
        public string Body { get; set; }
        
        public Book Book { get; set; }
    }
}
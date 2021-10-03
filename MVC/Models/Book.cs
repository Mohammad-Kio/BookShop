using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Book : BaseModel
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [MaxLength(30)]
        public string Isbn { get; set; }

        public List<Author> Authors{ get; set; }

    }
}

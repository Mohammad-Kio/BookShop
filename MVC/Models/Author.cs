using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Author : BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        public string Slug { get; set; }

        public List<Book> Books { get; set; }
        
    }
}
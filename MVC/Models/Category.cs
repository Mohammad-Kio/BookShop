using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Category : BaseModel
    {

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
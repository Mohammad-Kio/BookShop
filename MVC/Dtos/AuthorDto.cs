using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC.Dtos
{
    public class AuthorDto
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Slug { get; set; }

    }

    public class ReturnAuthorDto
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Slug { get; set; }

        public IEnumerable<ReturnBookDto> Books { get; set; }
    }

    public class GetAuthorDto
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
    }

    public class UpdateAuthorDto
    {
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
    }
}
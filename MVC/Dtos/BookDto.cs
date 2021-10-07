using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Isbn { get; set; }

        public string Slug { get; set; }

        public IEnumerable<AuthorDto> Authors { get; set; }

        public IEnumerable<CategoryDto> Categories { get; set; }
        
        public IEnumerable<CommentDto> Comments { get; set; }
    }

    public class GetBookDto
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; } = "";
        [Required]
        public string Isbn { get; set; }

        public List<int> CategoriesId { get; set; } = new List<int>();
        //
        // [Required]
        // [FromForm]
        // public IFormFile Image { get; set; }
        
        

    }

    public class UpdateBookDto
    {
        public string Title { get; set; }

        public string Description { get; set; } = "";

        public string Isbn { get; set; }
    }
    
}


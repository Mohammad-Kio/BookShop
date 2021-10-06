using System.Collections;
using System.Collections.Generic;

namespace MVC.VM
{
    public class BookVm
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Isbn { get; set; }

        public string Slug { get; set; }

        public IEnumerable<AuthorVm> Authors { get; set; }
    }
}
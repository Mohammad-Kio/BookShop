using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MVC.Models;

namespace MVC.VM
{
    public class AuthorVm
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

    }
}
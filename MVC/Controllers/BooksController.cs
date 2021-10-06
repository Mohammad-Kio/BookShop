using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Services;

namespace MVC.Controllers
{
    [ApiController]
    [Route("/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBaseRepository<Book> _bookRepo;

        public BooksController(IBaseRepository<Book> bookRepo)
        {
            _bookRepo = bookRepo;
        }
        
        public async Task<IActionResult> GetBooks()
        {
            var res = await _bookRepo.GetAllAsync();
            return Ok(res);
        }
    }
}
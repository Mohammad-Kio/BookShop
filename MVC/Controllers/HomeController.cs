using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MVC.Services;
using MVC.VM;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Book> _bookRepo;

        public HomeController(ILogger<HomeController> logger, IMapper _mapper, IBaseRepository<Book> bookRepo)
        {
            _logger = logger;
            this._mapper = _mapper;
            _bookRepo = bookRepo;
        }

        public IActionResult Index()
        {
            var book = new Book()
            {
                Id = 1, 
                Title = "C#", 
                Description = "", 
                CreateAt = DateTime.Now, 
                UpdatedAt = DateTime.Now, 
                Isbn = "1234567890",
                ImageUrl = "iss",
                Authors = new List<Author>()
                {
                    new Author()
                    {
                        FirstName = "Mohammad",
                        LastName = "Mustafa",
                        Id = 1,
                        UpdatedAt = DateTime.Now,
                        CreateAt = DateTime.Now
                    },
                    new Author()
                    {
                        FirstName = "Mohammad",
                        LastName = "Mustafa",
                        Id = 1,
                        UpdatedAt = DateTime.Now,
                        CreateAt = DateTime.Now
                    }
                }
            };
            var r = _mapper.Map<BookVm>(book);
            return Ok(r);
        }

        public async Task<IActionResult> Privacy()
        {
            var x = await _bookRepo.GetAllAsync();
            return View();
        }

        
    }
}

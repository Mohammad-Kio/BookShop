using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVC.Dtos;
using MVC.Models;
using MVC.Repositories;
using MVC.Services;

namespace MVC.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IBaseRepository<Category> _catRepo;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Book> _bookRepo;

        public CategoryController(IBaseRepository<Category> catRepo, IMapper mapper, IBaseRepository<Book> bookRepo)
        {
            _catRepo = catRepo;
            _mapper = mapper;
            _bookRepo = bookRepo;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _catRepo.GetAllAsync());
        }
        
        [HttpGet("/{id}")]
        public async Task<IActionResult> GetCategoryWithBooks(int id)
        {
            var cat = await _catRepo.GetOne(id);
            if (cat is null)
            {
                return NotFound(new {error = $"There is no category with id {id}"});
            }
            var filter = new FilterRepo<Book>
            {
                Where = x => x.Categories.Contains(cat)
            };
            var r = await _bookRepo.GetAllAsync(filter);
            return Ok(_mapper.Map<IEnumerable<BookDto>>(r));
        }
        
        
    }
}
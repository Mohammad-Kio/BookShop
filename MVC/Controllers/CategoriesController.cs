using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class CategoriesController : ControllerBase
    {
        private readonly IBaseRepository<Category> _catRepo;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Book> _bookRepo;

        public CategoriesController(IBaseRepository<Category> catRepo, IMapper mapper, IBaseRepository<Book> bookRepo)
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
        
        [HttpGet("/[controller]/{id}")]
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

        [HttpPost]
        public async Task<IActionResult> CreateCategory([Required]string name)
        {
            var cat = new Category()
            {
                Name = name
            };

            await _catRepo.Save(cat);
            return Ok();
        }
        [HttpPatch("/[controller]/{id}")]
        public async Task<IActionResult> UpdateCategory([Required][FromRoute]int id, [Required]string name)
        {
            var cat = await _catRepo.GetOne(id);
            if (cat is null)
                return NotFound(new {error = $"There is no Category with id {id}"});
            cat.Name = name;

            await _catRepo.Update(cat);
            return Ok(cat);
        }
        
        [HttpDelete("/[controller]/{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute]int id)
        {
            var cat = await _catRepo.GetOne(id);
            if(cat is null)
                return NotFound(new {error = $"There is no Category with id {id}"});

            _catRepo.Delete(cat);
            return Ok();
        }
    }
}
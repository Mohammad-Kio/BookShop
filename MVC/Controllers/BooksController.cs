using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Dtos;
using MVC.Helpers;
using MVC.Models;
using MVC.Repositories;
using MVC.Services;

namespace MVC.Controllers
{
    [ApiController]
    [Route("/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBaseRepository<Book> _bookRepo;
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Category> _catRepository;
        private readonly IWebHostEnvironment _env;

        public BooksController(IBaseRepository<Book> bookRepo,
            IMapper mapper,
            IBaseRepository<Category> catRepository,
            IWebHostEnvironment env)
        {
            _bookRepo = bookRepo;
            _mapper = mapper;
            _catRepository = catRepository;
            _env = env;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetBooks(int take = 0, int skip = 0, string sortBy = "ASC", string name = null)
        {
            FilterRepo < Book > filter = new FilterRepo<Book>(take, skip, sortBy);
            
            if (!string.IsNullOrEmpty(name))
            {
                filter.Where = x => x.Title == name;
            }
            
            filter.Include.Add(x => x.Authors);
            filter.Include.Add(x => x.Categories.Take(5));
            filter.OrderBy = x => x.Title;

            
            var res = await _bookRepo.GetAllAsync(filter);

            return Ok(_mapper.Map<IEnumerable<BookDto>>(res));
        }


        [HttpPost]
        public async Task<IActionResult> CreateBook(GetBookDto bok)
        {
            
            var book = new Book
            {
                Title = bok.Title,
                Isbn = bok.Isbn,
                Description = bok.Description,
                Slug = SlugGen.GenerateBookSlug(bok.Title),
                Categories = new List<Category>()
            };

            var cats = await _catRepository.GetManyAsync(bok.CategoriesId);

            foreach (var cat in cats)  
            {
                book.Categories.Add(cat);
            }
            
            await _bookRepo.Save(book);

            
            return Ok(_mapper.Map<BookDto>(book));
        }

        [HttpPost("/books/image/{id}")]
        public async Task<IActionResult> AddImage([FromRoute]int id, [Required]IFormFile file)
        {
            // file.CopyToAsync()
            
            if (file.ContentType != "image/jpeg")
            {
                return BadRequest("Unsupported File Type");
            }
            var book = await _bookRepo.GetOne(id);


            var fileName = file.FileName
                                     + "-"
                                     + book.Id
                                     + "."
                                     + file.ContentType.Split("/")[1];
            var filePath = _env.WebRootPath + "/images";

            
            await using (var stream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            book.ImageUrl = "/images/" + fileName;
            await _bookRepo.Update(book);

            return Ok();
        }

        [HttpGet("/books/{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var filter = new FilterRepo<Book>
            {
                Where = b => b.Id == id
            };
            filter.Include.Add(b => b.Authors);
            filter.Include.Add(b => b.Categories);
            filter.Include.Add(b => b.Comments.Take(5));
            var book = await _bookRepo.GetOne(filter);
            return Ok(_mapper.Map<BookDto>(book));

        }

        [HttpPatch("/books/{id}")]
        public async Task<IActionResult> UpdateBook(int id, UpdateBookDto bok)
        {
            
            var book = await _bookRepo.GetOne(id);
            if (book is null)
                return NotFound($"No book with id {id} was found");

            book.Title = !string.IsNullOrEmpty(bok.Title) ? bok.Title : book.Title;
            book.Isbn = !string.IsNullOrEmpty(bok.Isbn) ? bok.Isbn : book.Isbn;
            book.Description= !string.IsNullOrEmpty(bok.Description) ? bok.Description : book.Description;
            book.Slug = !string.IsNullOrEmpty(bok.Title) ? SlugGen.GenerateBookSlug(bok.Title) : book.Slug;
            await _bookRepo.Update(book);
            
            return Ok(_mapper.Map<UpdateBookDto>(book));
        }

        [HttpDelete("/books/id")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _bookRepo.GetOne(id);
            if (book is null)
                return NotFound($"No book with id {id} was found");
            
            _bookRepo.Delete(book);
            return Ok();
        }

    }
}
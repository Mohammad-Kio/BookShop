using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVC.Dtos;
using MVC.Helpers;
using MVC.Models;
using MVC.Repositories;
using MVC.Services;

namespace MVC.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Author> _authorRepo;

        public AuthorsController(IMapper mapper,
            IBaseRepository<Author> authorRepo)
        {
            _mapper = mapper;
            _authorRepo = authorRepo;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(await _authorRepo.GetAllAsync()));
        }

        [HttpGet("/[controller]/{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var filter = new FilterRepo<Author>();
            filter.Include.Add(x => x.Books);
            
            filter.Where = x => x.Id == id;

            var author = await _authorRepo.GetOne(filter);
            if (author is null)
                return NotFound(new {error = $"No Author found with id {id}"});

            var r = _mapper.Map<ReturnAuthorDto>(author);
            return Ok(r);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(GetAuthorDto authorDto)
        {
            var author = new Author()
            {
                FirstName = authorDto.FirstName,
                LastName = authorDto.LastName,
                Slug = SlugGen.GenerateSlug($"{authorDto.FirstName}-{authorDto.LastName}")
            };
            await _authorRepo.Save(author);

            return Ok(author);
        }

        [HttpPatch("/[controller]/{id}")]
        public async Task<IActionResult> UpdateAuthor([Required][FromRoute]int id,[FromBody]UpdateAuthorDto author)
        {
            var uauthor = await _authorRepo.GetOne(id);

            if (uauthor is null)
                return NotFound(new {error = $"No author with id {id} was found"});
            
            uauthor.FirstName = !string.IsNullOrEmpty(author.FirstName) ? author.FirstName: uauthor.FirstName;
            uauthor.LastName = !string.IsNullOrEmpty(author.LastName) ? author.LastName: uauthor.LastName;
            uauthor.Slug = SlugGen.GenerateSlug($"{uauthor.FirstName}-{uauthor.LastName}");

            await _authorRepo.Update(uauthor);
            return Ok(uauthor);
        }

        [HttpDelete("/[controller]/{id}")]
        public async Task<IActionResult> DeleteAuthor([Required]int id)
        {
            var author = await _authorRepo.GetOne(id);
            if(author is null)
                return NotFound(new {error = $"No author with id {id} was found"});
            
            _authorRepo.Delete(author);
            return Ok();
        }
    }
}










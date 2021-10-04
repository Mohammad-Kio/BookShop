using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MVC.Repositories;
using MVC.Services;
using MVC.VM;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Book> _bookRepo;
        // private readonly FilterRepo<Book> _filterRepo;

        public HomeController( IMapper mapper, IBaseRepository<Book> bookRepo)
        {
            this._mapper = mapper;
            _bookRepo = bookRepo;
        }

        public async Task<IActionResult> Index()
        {
            var filter = new FilterRepo<Book>(10, 0, "D");
            filter.OrderBy = b => b.Title;
            filter.Where = b => b.Id == 1;
            filter.Include.Add(x => x.Authors);
            var res = await _bookRepo.GetAllAsync(filter);
            
            var r = _mapper.Map<IEnumerable<BookVm>>(res);
            return View(r);
        }

        public async Task<IActionResult> Privacy()
        {
            var x = await _bookRepo.GetAllAsync();
            return View(x);
        }

        
    }
}

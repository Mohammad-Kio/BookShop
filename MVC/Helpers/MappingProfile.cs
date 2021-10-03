using System.Linq;
using AutoMapper;
using MVC.Models;
using MVC.VM;

namespace MVC.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorVm>();
            CreateMap<Book, BookVm>();
        }
    }
}
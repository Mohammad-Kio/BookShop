using AutoMapper;
using MVC.Dtos;
using MVC.Models;

namespace MVC.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, UpdateBookDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Author, AuthorDto>();
            CreateMap<Book, BookDto>();
        }
    }
}
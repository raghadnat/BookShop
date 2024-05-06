using AutoMapper;
using BookShop.DAL.Entites;
using BookShop.Domain.DTOs;
using BookShop.Utilities;

namespace BookShop.Domain.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Book, BookDtos>().ReverseMap();
            CreateMap<Student, StudentDtos>().ReverseMap();
            CreateMap<PaginatedResult<Book>, PaginatedResult<BookDtos>>().ReverseMap();
            CreateMap<CreateUpdateBookRequest, Book>().ReverseMap();
        }
    }
}

using AutoMapper;
using BookShop.DAL.Entites;
using BookShop.Domain.DTOs;
using BookShop.Domain.Repositories;
using BookShop.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        public readonly BookRepository _Repository;
        private readonly IMapper _mapper;

        public BooksController(BookRepository bookRepository, IMapper mapper) 
        {
            _Repository = bookRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("api/book/Borrow/{id}/{studentId}")]
        public async Task<ActionResult<BookDtos>> Borrow(int id,int studentId)
        {
            ///get student id form request 
            var currentUser = HttpContext.User;
            
            var Books = await _Repository.GetByStudentId(studentId);
            if (Books.Count() > 2)
            {
                return BadRequest("student couldn't borrow more than two books!");
            }

            var RequestedBook = await _Repository.GetByIdAsync(id);
            if (RequestedBook.IsBooked)
            {
                return BadRequest("Book Not Available!");

            }
            RequestedBook.StudentId =studentId;
            RequestedBook.IsBooked = true;

            await _Repository.UpdateAsync(RequestedBook);
            await _Repository.SaveAsync();

            return _mapper.Map<BookDtos>(RequestedBook);
        }


        [HttpGet("api/book/GetAll")]
        public async Task<PaginatedResult<BookDtos>> GetAll(int pageSize = 20,
                                                                       int pageNumber = 0)
        {
            var Books = await _Repository.GetPagedAsync(pageSize, pageNumber);
            var Result = _mapper.Map<PaginatedResult<BookDtos>>(Books);
            return Result;
        }

        [HttpGet("api/book/{id}")]
        public async Task<ActionResult<BookDtos>> Get(int id)
        {
            var _Book = await _Repository.GetByIdAsync(id);
            if (_Book == null)
            {
                return NotFound();
            }
            var Result = _mapper.Map<BookDtos>(_Book);
            return Result;
        }

        [HttpPut("api/book/{id}")]
        public async Task<IActionResult> Put(int id, CreateUpdateBookRequestDto book)
        {
            var CurrentBook = await _Repository.GetByIdAsync(id);
            if (CurrentBook == null)
            {
                return NotFound();
            }
            var Book = _mapper.Map<Book>(book);
            await _Repository.UpdateAsync(Book);
            await _Repository.SaveAsync();

            return NoContent();
        }

        [HttpPost("api/book/Add")]
        public async Task<ActionResult<BookDtos>> PostBook(CreateUpdateBookRequestDto book)
        {
            var Data = _mapper.Map<Book>(book);

            await _Repository.InsertAsync(Data);
            await _Repository.SaveAsync();
            return _mapper.Map<BookDtos>(Data);
        }

        [HttpDelete("api/book/{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var Book = await _Repository.GetByIdAsync(id);
            if (Book == null)
            {
                return NotFound();
            }
            if (Book.IsBooked)
            {
                return BadRequest("can't delete borrowed book ");
            }
             await _Repository.DeleteAsync(id);
            await _Repository.SaveAsync();

            return true;
        }

    }
}

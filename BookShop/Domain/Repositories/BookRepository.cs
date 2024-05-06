using BookShop.DAL.Context;
using BookShop.DAL.Entites;
using BookShop.DAL.MainRepository;
using BookShop.Utilities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookShop.Domain.Repositories
{
    public class BookRepository : MainRepository<Book>
    {
        private readonly DBContext _context;
        public BookRepository(DBContext context) :base(context)
        {
            _context = context;
        }
        public async Task<List<Book>> GetByStudentId(int id)
        {
            var Result = await _context.Books.Include(e => e.Student).Where(x=>x.StudentId == id).ToListAsync();
            return Result;
        }

    }
}

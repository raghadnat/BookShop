using BookShop.DAL.Context;
using BookShop.DAL.Entites;
using BookShop.DAL.MainRepository;
using BookShop.Utilities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookShop.Domain.Repositories
{
    public class BookRepository : IMainRepository<Book>
    {
        private readonly DBContext _context;
        public BookRepository(DBContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int Id)
        {
            var book = await _context.Books.FindAsync(Id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
        }
        public async Task<PaginatedResult<Book>> GetPagedAsync(int pageSize = 20,int pageNumber = 0)
        {
            var Result =await _context.Books.Include(e => e.Student).paginate(pageSize, pageNumber);
    
            return Result;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var Result =  await _context.Books.Include(e => e.Student).ToListAsync();
            return Result;
        }
        public async Task<List<Book>> GetByStudentId(int id)
        {
            var Result = await _context.Books.Include(e => e.Student).Where(x=>x.StudentId == id).ToListAsync();
            return Result;
        }

        public async Task<Book?> GetByIdAsync(int Id)
        {
            var book = await _context.Books
              .Include(e => e.Student)
              .FirstOrDefaultAsync(m => m.Id == Id);

            return book;
        }

        public async Task InsertAsync(Book entity)
        {
            await _context.Books.AddAsync(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book entity)
        {
            _context.Books.Update(entity);
        }

    }
}

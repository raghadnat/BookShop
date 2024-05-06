using BookShop.DAL.Context;
using BookShop.Utilities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.DAL.MainRepository
{
    public class MainRepository<T>: IMainRepository<T>   where T : class
    {
        private readonly DBContext _context;
        public MainRepository(DBContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int Id)
        {
            var Result = await _context.Set<T>().FindAsync(Id);
            if (Result != null)
            {
                _context.Set<T>().Remove(Result);
            }
        }
        public async Task<PaginatedResult<T>> GetPagedAsync(int pageSize = 20, int pageNumber = 0)
        {
            var Result = await _context.Set<T>().paginate(pageSize, pageNumber);

            return Result;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var Result = await _context.Set<T>().ToListAsync();
            return Result;
        }
       
        public async Task<T?> GetByIdAsync(int Id)
        {
            var Result = await _context.Set<T>().FindAsync(Id);

            return Result;
        }

        public async Task InsertAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
        }

    }
}

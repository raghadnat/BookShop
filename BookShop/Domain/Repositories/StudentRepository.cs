using BookShop.DAL.Context;
using BookShop.DAL.Entites;
using BookShop.DAL.MainRepository;
using Microsoft.EntityFrameworkCore;

namespace BookShop.DAL.Repositories
{
    public class StudentRepository : MainRepository<Student>
    {
        private readonly DBContext _context;
        public StudentRepository(DBContext context) :base(context) 
        {
            this._context = context;
        }
        public async Task<Student?> GetByStudentNumebrsync(int Number,string UserName)
        {
            var student = await _context.Students
            .FirstOrDefaultAsync(m => m.StudentNumber == Number && m.Name == UserName);

            return student;
        }

    }
}

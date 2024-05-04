using BookShop.DAL.Context;
using BookShop.DAL.Entites;
using BookShop.DAL.MainRepository;
using Microsoft.EntityFrameworkCore;

namespace BookShop.DAL.Repositories
{
    public class StudentRepository : IMainRepository<Student>
    {
        private readonly DBContext _context;
        public StudentRepository(DBContext context)
        {
            this._context = context;
        }

        public async Task DeleteAsync(int Id)
        {
            var student = await _context.Students.FindAsync(Id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            var student = await _context.Students.ToListAsync();
            return student;
        }

        public async  Task<Student?> GetByIdAsync(int Id)
        {
            var student = await _context.Students
            .FirstOrDefaultAsync(m => m.Id == Id);

            return student;
        }
        public async Task<Student?> GetByStudentNumebrsync(int Number,string UserName)
        {
            var student = await _context.Students
            .FirstOrDefaultAsync(m => m.StudentNumber == Number && m.Name == UserName);

            return student;
        }

        public async Task InsertAsync(Student entity)
        {
            await _context.Students.AddAsync(entity);
        }

        public async  Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student entity)
        {
             _context.Students.Update(entity);
        }
    }
}

using BookShop.DAL.Entites;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Domain.DTOs
{
    public class StudentDtos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentNumber { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}

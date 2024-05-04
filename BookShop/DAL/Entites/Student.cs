using System.ComponentModel.DataAnnotations;

namespace BookShop.DAL.Entites
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int StudentNumber { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}

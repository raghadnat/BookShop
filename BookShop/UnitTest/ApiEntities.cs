using BookShop.DAL.Entites;
using System.ComponentModel.DataAnnotations;

namespace BookShop.UnitTest
{
    public class ApiEntities
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int price { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }
        public bool IsBooked { get; set; }
        public Student Student { get; set; }
    }
}

using BookShop.DAL.Entites;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Domain.DTOs
{
    public class CreateUpdateBookRequestDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public int price { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public int PublicationYear { get; set; }
    }
}

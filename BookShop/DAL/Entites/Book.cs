using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace BookShop.DAL.Entites
{
    public class Book
    {
        [Key]
        public int Id {get;set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int price { get; set; }
        [Required]
        public bool IsBooked { get; set; } = false;
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public int? PublicationYear { get; set; }
        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }
       
    }
}

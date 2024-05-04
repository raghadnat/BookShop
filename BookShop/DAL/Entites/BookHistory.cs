using System.ComponentModel.DataAnnotations;

namespace BookShop.DAL.Entites
{
    public class BookHistory
    {
        [Key]
        public int BookId { get; set; }
        public int StudentId { get; set; }
        public DateTime BorrowDate { get; set; }
       
    }
}

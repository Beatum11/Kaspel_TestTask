using BooksStore.Data;

namespace BooksStore.DTOs.Books
{
    public class AddBookDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishedOn { get; set; }
        public DateTime? ArrivedAtStore { get; set; } = DateTime.Now;
        public decimal Price { get; set; }
        public int OrderId { get; set; }
    }
}

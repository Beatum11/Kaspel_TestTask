using BooksStore.Data;

namespace BooksStore.DTOs.Books
{
    public class GetBookDTO
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public DateTime? PublishedOn { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
    }
}

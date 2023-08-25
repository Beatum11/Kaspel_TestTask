namespace BooksStore.DTOs.Books
{
    public class UpdateBookDTO
    {
        public int Id { get; set; }
        public DateTime? ArrivedAtStore { get; set; }
        public decimal Price { get; set; }
    }
}

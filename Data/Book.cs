namespace BooksStore.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public DateTime? PublishedOn { get; set; }
        public DateTime? ArrivedAtStore { get; set; }
        public decimal Price { get; set; }
        public Order? Order { get; set; }
    }
}

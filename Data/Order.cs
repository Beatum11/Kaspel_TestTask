namespace BooksStore.Data
{
    public class Order
    {
        public int Id { get; set; }
        public string? OrderNumber { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public string? CustomerName { get; set; }

        public string? Comment { get; set; }

        public decimal TotalPrice { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}

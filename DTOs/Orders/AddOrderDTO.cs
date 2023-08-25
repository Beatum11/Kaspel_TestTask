using BooksStore.Data;

namespace BooksStore.DTOs.Orders
{
    public class AddOrderDTO
    {
        public string? OrderNumber { get; set; }
        public string? CustomerName { get; set; }
        public string? Comment { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<Book>? Books { get; set; }

    }
}

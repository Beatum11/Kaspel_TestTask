using BooksStore.Data;

namespace BooksStore.DTOs.Orders
{
    public class UpdateOrderDTO
    {
        public int Id { get; set; }

        public string? OrderNumber { get; set; }
        public ICollection<Book>? Books { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}

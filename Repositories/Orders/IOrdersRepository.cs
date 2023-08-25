using BooksStore.DTOs.Orders;
using BooksStore.Services;

namespace BooksStore.Repositories.Orders
{
    public interface IOrdersRepository
    {
        Task<ServiceResponse<IEnumerable<GetOrderDTO>>> GetOrders(string? orderNum, DateTime? date);
        Task<ServiceResponse<GetOrderDTO>> GetOrder(int id);
        Task<ServiceResponse<GetOrderDTO>> CreateOrder(AddOrderDTO newOrder);
        Task<ServiceResponse<GetOrderDTO>> UpdateOrder(UpdateOrderDTO updatedOrder);
        Task DeleteOrder(int id);
    }
}

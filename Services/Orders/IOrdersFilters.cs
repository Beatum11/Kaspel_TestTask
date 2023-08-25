
using BooksStore.DTOs.Orders;

namespace BooksStore.Services.Orders
{
    public interface IOrdersFilters
    {
        Task<ServiceResponse<IEnumerable<GetOrderDTO>>> FilterByOrderNum(string orderNum);
        Task<ServiceResponse<IEnumerable<GetOrderDTO>>> FilterByOrderDate(DateTime? orderDate);
    }
}

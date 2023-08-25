using AutoMapper;
using BooksStore.Data;
using BooksStore.DTOs.Books;
using BooksStore.DTOs.Orders;
using BooksStore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Services.Orders
{
    public class OrdersFilters: BaseRepository, IOrdersFilters
    {
        public OrdersFilters(AppDbContext _context, IMapper _mapper) : base(_context, _mapper) { }

        public async Task<ServiceResponse<IEnumerable<GetOrderDTO>>> FilterByOrderNum(string orderNum)
        {
            var response = ServiceResponseFactory.CreateFailureResponse<IEnumerable<GetOrderDTO>>();


            try
            {
                var orders = await context.Orders.Where(o => o.OrderNumber == orderNum)
                                                  .Include(o => o.Books)
                                                  .ToListAsync();
                if(orders != null)
                {
                    response.Data = orders.Select(o => mapper.Map<GetOrderDTO>(o));
                    response.Success = true;
                }
                else
                    response.Message = "No orders with this number";
            } 
            catch (Exception ex) 
            {
                response.Message = ex.Message;         
            }

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetOrderDTO>>> FilterByOrderDate(DateTime? orderDate)
        {
            var response = ServiceResponseFactory.CreateFailureResponse<IEnumerable<GetOrderDTO>>();

            try
            {
                var orders = await context.Orders.Where(o => o.OrderDate == orderDate)
                                                  .Include(o => o.Books)
                                                  .ToListAsync();
                if (orders != null)
                {
                    response.Data = orders.Select(o => mapper.Map<GetOrderDTO>(o));
                    response.Success = true;
                }
                else
                {
                    response.Message = "No orders with this date";
                }

                
            } 
            catch (Exception ex) 
            {
                response.Message= ex.Message;
            }

            return response;
        }
    }
}

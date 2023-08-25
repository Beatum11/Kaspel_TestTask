using AutoMapper;
using BooksStore.Data;
using BooksStore.DTOs.Orders;
using BooksStore.Services;
using BooksStore.Services.Orders;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Repositories.Orders
{
    public class OrdersRepository : BaseRepository, IOrdersRepository
    {
        #region Setup

        private readonly OrdersFilters filters;
        public OrdersRepository(AppDbContext _context, 
                                IMapper _mapper, 
                                OrdersFilters _filters): base(_context, _mapper) 
        { 
            filters = _filters;
        }

        #endregion

        public async Task<ServiceResponse<IEnumerable<GetOrderDTO>>> GetOrders(string? orderNum, DateTime? date)
        {
            var response = ServiceResponseFactory.CreateFailureResponse<IEnumerable<GetOrderDTO>>();

            try
            {
                if (orderNum != null)
                    response = await filters.FilterByOrderNum(orderNum);
                if (date != null)
                    response = await filters.FilterByOrderDate(date);
                else
                {
                    var orders = await context.Orders.Include(o => o.Books).ToListAsync();
                    response.Data = orders.Select(o => mapper.Map<GetOrderDTO>(o));
                    response.Success = true;
                }
                   
            } 
             catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetOrderDTO>> GetOrder(int id)
        {
            var response = ServiceResponseFactory.CreateFailureResponse<GetOrderDTO>();

            try
            {
                var order = context.Orders.Where(o => o.Id == id)
                                          .Include(o => o.Books)
                                          .FirstOrDefaultAsync();

                if(order != null)
                {
                    response.Data = mapper.Map<GetOrderDTO>(order);
                    response.Success = true;
                } 
                else
                    response.Message = "Order not found";

            } 
            catch(Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetOrderDTO>> CreateOrder(AddOrderDTO newOrder)
        {
            var response = ServiceResponseFactory.CreateFailureResponse<GetOrderDTO>();
            try
            {
                var order = mapper.Map<Order>(newOrder);
                await context.Orders.AddAsync(order);
                await context.SaveChangesAsync();

                response.Success = true;
                response.Data = mapper.Map<GetOrderDTO>(order);
            } 
            catch(Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetOrderDTO>> UpdateOrder(UpdateOrderDTO updatedOrder)
        {
            var response = ServiceResponseFactory.CreateFailureResponse<GetOrderDTO>();

            try
            {
                var order = await context.Orders.Where(o => o.Id == updatedOrder.Id)
                                                .Include(o => o.Books)
                                                .FirstOrDefaultAsync();
                if(order != null)
                {
                    order.OrderNumber = updatedOrder.OrderNumber;
                    order.OrderDate = updatedOrder.OrderDate;
                    order.TotalPrice = updatedOrder.TotalPrice;

                    if(updatedOrder.Books != null)
                    {
                        order?.Books?.Clear();
                        foreach(var book in updatedOrder.Books)
                        {
                            var bookToAdd = await context.Books.FirstOrDefaultAsync(b => b.Id == book.Id);
                            order?.Books?.Add(bookToAdd);
                        }
                    }

                    context.Orders.Update(order);
                    await context.SaveChangesAsync();

                    response.Success = true;
                    response.Data = mapper.Map<GetOrderDTO>(order);
                }
                else
                    response.Message = "Order not found";   
            } 
            catch(Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task DeleteOrder(int id)
        {
           var order = await context.Orders.Where(o => o.Id == id)
                                .Include(o => o.Books)
                                .FirstOrDefaultAsync();
            if(order != null)
            {
                context.Orders.Remove(order);
                await context.SaveChangesAsync();
            }
            else
                throw new Exception("Order not found");  
        }
    }
}

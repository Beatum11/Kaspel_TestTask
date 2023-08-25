using AutoMapper;
using BooksStore.Data;
using BooksStore.DTOs.Books;
using BooksStore.DTOs.Orders;

namespace BooksStore.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, GetBookDTO>().ReverseMap();
            CreateMap<AddBookDTO, Book>().ReverseMap();
            CreateMap<UpdateBookDTO, Book>().ReverseMap();

            CreateMap<Order, GetOrderDTO>().ReverseMap();
            CreateMap<Order, AddOrderDTO>().ReverseMap();
            CreateMap<Order, UpdateOrderDTO>().ReverseMap();

        }


    }
}

using AutoMapper;
using Azure;
using BooksStore.Data;
using BooksStore.DTOs.Books;
using BooksStore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Services.Books
{
    public class BooksFilters : BaseRepository, IBooksFilters
    {
        public BooksFilters(AppDbContext _context, IMapper _mapper): base(_context, _mapper) { }

        public async Task<ServiceResponse<IEnumerable<GetBookDTO>>> FilterByTitle(string title)
        {
            var response = ServiceResponseFactory.CreateFailureResponse<IEnumerable<GetBookDTO>>();

            try
            {
                var books = await context.Books.Where(b => b.Title == title)
                                                .Include(b => b.Order)
                                                .ToListAsync();
                if(books != null)
                {
                    response.Data = books.Select(b => mapper.Map<GetBookDTO>(b));
                    response.Success = true;
                }
                else
                    response.Message = "0 books with this title";
            } 
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetBookDTO>>> FilterByDate(DateTime? date)
        {
            var response = ServiceResponseFactory.CreateFailureResponse<IEnumerable<GetBookDTO>>();

            try
            {
                var books = await context.Books.Where(b => b.PublishedOn == date)
                                                .Include(b => b.Order)
                                                .ToListAsync();
                if (books != null)
                {
                    response.Data = books.Select(b => mapper.Map<GetBookDTO>(b));
                    response.Success = true;
                }
                else
                    response.Message = "0 books with this date";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}

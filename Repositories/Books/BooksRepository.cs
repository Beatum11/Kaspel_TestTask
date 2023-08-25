using AutoMapper;
using BooksStore.Data;
using BooksStore.DTOs.Books;
using BooksStore.Services;
using BooksStore.Services.Books;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Repositories.Books
{
    public class BooksRepository : BaseRepository, IBooksRepository 
    {
        #region Setup

        private readonly BooksFilters filters;
        public BooksRepository(AppDbContext _context, 
                               IMapper _mapper, 
                               BooksFilters _filters): base(_context, _mapper)
        {
            filters = _filters;
        }

        #endregion


        public async Task<ServiceResponse<IEnumerable<GetBookDTO>>> GetBooks(string? title, DateTime? date)
        {
            var response = ServiceResponseFactory.CreateFailureResponse<IEnumerable<GetBookDTO>>();
            try
            {
                if (title != null)
                    response = await filters.FilterByTitle(title);
                if (date != null)
                    response = await filters.FilterByDate(date);
                else
                {
                    var books = await context.Books.Include(b => b.Order).ToListAsync();
                    response.Data = books.Select(b => mapper.Map<GetBookDTO>(b));
                    response.Success = true;
                }
            } catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
            
        }

        public async Task<ServiceResponse<GetBookDTO>> GetBook(int id)
        {
           var response = ServiceResponseFactory.CreateFailureResponse<GetBookDTO>();

            try
            {
                var book = await context.Books.Where(b => b.Id == id)
                                              .Include(b => b.Order)
                                              .FirstOrDefaultAsync();

                if(book != null)
                {
                    response.Data = mapper.Map<GetBookDTO>(book);
                    response.Success = true;
                } 
                else
                    response.Message = "Book not found";
            } 
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetBookDTO>> CreateBook(AddBookDTO newBook)
        {
            var response = ServiceResponseFactory.CreateFailureResponse<GetBookDTO>();

            try
            {
                var book = mapper.Map<Book>(newBook);
                await context.Books.AddAsync(book);
                await context.SaveChangesAsync();

                response.Data = mapper.Map<GetBookDTO>(book);
                response.Success = true;
            } 
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetBookDTO>> UpdateBook(UpdateBookDTO updatedBook)
        {
            var response = ServiceResponseFactory.CreateFailureResponse<GetBookDTO>();

            try
            {
                var book = await context.Books
                                            .Include(b => b.Order)      
                                            .FirstOrDefaultAsync(b => b.Id == updatedBook.Id);

                if(book != null)
                {
                    book.ArrivedAtStore = updatedBook.ArrivedAtStore;
                    book.Price = updatedBook.Price;

                    context.Books.Update(book);
                    await context.SaveChangesAsync();

                    response.Data = mapper.Map<GetBookDTO>(book);
                    response.Success = true;
                } 
                else
                    response.Message = "Book not found";
            } 
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task DeleteBook(int id)
        {
            var book = await context.Books
                                        .Include(b => b.Order)
                                        .FirstOrDefaultAsync(b => b.Id == id);
            if(book != null)
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
            } 
            else
                throw new Exception("Book not found");
        }
    }
}

using BooksStore.Data;
using BooksStore.DTOs.Books;
using BooksStore.Services;

namespace BooksStore.Repositories.Books
{
    public interface IBooksRepository
    {
        Task<ServiceResponse<IEnumerable<GetBookDTO>>> GetBooks(string? title, DateTime? date);
        Task<ServiceResponse<GetBookDTO>> GetBook(int id);
        Task<ServiceResponse<GetBookDTO>> CreateBook(AddBookDTO newBook);
        Task <ServiceResponse<GetBookDTO>> UpdateBook(UpdateBookDTO updatedBook);
        Task DeleteBook(int id);
    }
}

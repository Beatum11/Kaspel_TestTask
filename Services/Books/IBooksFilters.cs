using BooksStore.DTOs.Books;

namespace BooksStore.Services.Books
{
    public interface IBooksFilters
    {
        Task<ServiceResponse<IEnumerable<GetBookDTO>>> FilterByTitle(string title);
        Task<ServiceResponse<IEnumerable<GetBookDTO>>> FilterByDate(DateTime? date);
    }
}

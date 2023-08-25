using BooksStore.DTOs.Orders;

namespace BooksStore.Services
{
    //This class encapsulates the logic of creating failure responses
    internal static class ServiceResponseFactory
    {
        internal static ServiceResponse<T> CreateFailureResponse<T>() where T : class
        {
            return new ServiceResponse<T>()
            {
                Success = false
            };
        }
    }
}

using AutoMapper;
using BooksStore.Data;

namespace BooksStore.Repositories
{
    // Base class for encapsulating dependencies
    public class BaseRepository
    {
        protected readonly AppDbContext context;
        protected readonly IMapper mapper;

        public BaseRepository(AppDbContext _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
    }
}

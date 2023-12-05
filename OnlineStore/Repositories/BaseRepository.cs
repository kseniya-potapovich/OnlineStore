using OnlineStore.Data;

namespace OnlineStore.Repositories
{
    public class BaseRepository
    {
        public readonly OnlineStoreDbContext _context;

        public BaseRepository(OnlineStoreDbContext context)
        {
            _context = context;
        }
    }
}

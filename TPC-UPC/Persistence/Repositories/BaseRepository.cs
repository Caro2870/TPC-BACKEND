using System;
using TPC_UPC.Domain.Persistence.Contexts;

namespace TPC_UPC.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}

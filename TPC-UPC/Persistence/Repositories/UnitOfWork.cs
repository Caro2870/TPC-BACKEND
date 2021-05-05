using System;
using System.Threading.Tasks;
using TPC_UPC.Domain.Persistence.Contexts;
using TPC_UPC.Domain.Persistence.Repositories;

namespace TPC_UPC.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

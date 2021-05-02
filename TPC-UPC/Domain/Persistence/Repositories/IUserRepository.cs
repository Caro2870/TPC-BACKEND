using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;


namespace TPC_UPC.Domain.Persistence.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task AddAsync(User user);
        Task<User> FindById(int id);
        void Update(User user);
        void Remove(User user);
    }
}

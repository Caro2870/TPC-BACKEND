using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
namespace TPC_UPC.Domain.Persistence.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> ListAsync();
        Task AddAsync(Student student);
        Task<Student> FindById(int id);
        void Update(Student student);
        void Remove(Student student);
    }
}

using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using TPC_UPC.Domain.Models;

 namespace TPC_UPC.Domain.Persistence.Repositories
 {
     public interface ITutorRepository
     {
        //CRUD
        Task AddAsync(Tutor tutor);
        Task<Tutor> FindById(int id);
        void Update(Tutor tutor);
        void Remove(Tutor tutor);

        //ADDED
        Task<IEnumerable<Tutor>> ListAsync();
    }
 }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> ListAsync();
        Task<IEnumerable<Student>> ListByCareerIdAsync(int careerId);

        //CRUD
        Task<StudentResponse> GetByIdAsync(int id);
        Task<StudentResponse> SaveAsync(Student student);
        Task<StudentResponse> UpdateASync(int id, Student student);
        Task<StudentResponse> DeleteAsync(int id);

       
    }
}

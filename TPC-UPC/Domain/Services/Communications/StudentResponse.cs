using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domain.Models;

namespace Web.Domain.Services.Communications
{
    public class StudentResponse : BaseResponse<Student>
    {
        public StudentResponse(Student resource) : base(resource)
        {
        }

        public StudentResponse(string message) : base(message)
        {
        }
    }
}

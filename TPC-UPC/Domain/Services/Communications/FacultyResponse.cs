using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domain.Models;

namespace Web.Domain.Services.Communications
{
    public class FacultyResponse : BaseResponse<Faculty>
    {
        public FacultyResponse(Faculty resource) : base(resource)
        {
        }

        public FacultyResponse(string message) : base(message)
        {
        }
    }
}

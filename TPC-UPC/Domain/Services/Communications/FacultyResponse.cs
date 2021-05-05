using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;

namespace TPC_UPC.Domain.Services.Communications
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

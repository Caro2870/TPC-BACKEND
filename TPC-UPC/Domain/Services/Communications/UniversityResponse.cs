using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;

namespace TPC_UPC.Domain.Services.Communications
{
    public class UniversityResponse : BaseResponse<University>
    {
        public UniversityResponse(University resource) : base(resource)
        {
        }

        public UniversityResponse(string message) : base(message)
        {
        }
    }
}

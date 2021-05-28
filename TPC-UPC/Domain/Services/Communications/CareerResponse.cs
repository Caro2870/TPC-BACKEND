using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;

namespace TPC_UPC.Domain.Services.Communications
{
    public class CareerResponse : BaseResponse<Career>
    {
        public CareerResponse(Career resource) : base(resource)
        {
        }

        public CareerResponse(string message) : base(message)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;

namespace TPC_UPC.Domain.Services.Communications
{
    public class CarrerResponse : BaseResponse<Career>
    {
        public CarrerResponse(Career resource) : base(resource)
        {
        }

        public CarrerResponse(string message) : base(message)
        {
        }
    }
}

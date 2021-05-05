using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domain.Models;

namespace Web.Domain.Services.Communications
{
    public class CarrerResponse : BaseResponse<Carrer>
    {
        public CarrerResponse(Carrer resource) : base(resource)
        {
        }

        public CarrerResponse(string message) : base(message)
        {
        }
    }
}

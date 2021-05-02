using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;

namespace TPC_UPC.Domain.Services.Communications
{
    public class CoordinatorResponse : BaseResponse<Coordinator>
    {
        public CoordinatorResponse(Coordinator resource) : base(resource)
        {
        }

        public CoordinatorResponse(string message) : base(message)
        {
        }
    }
}

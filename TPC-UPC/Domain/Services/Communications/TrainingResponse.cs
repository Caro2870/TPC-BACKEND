using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domain.Models;

namespace Web.Domain.Services.Communications
{
    public class TrainingResponse : BaseResponse<Training>
    {
        public TrainingResponse(Training resource) : base(resource)
        {
        }

        public TrainingResponse(string message) : base(message)
        {
        }
    }
}

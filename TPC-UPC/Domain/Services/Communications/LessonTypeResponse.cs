using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;

namespace TPC_UPC.Domain.Services.Communications
{
    public class LessonTypeResponse : BaseResponse<LessonType>
    {
        public LessonTypeResponse(LessonType resource) : base(resource)
        {
        }

        public LessonTypeResponse(string message) : base(message)
        {
        }
    }
}

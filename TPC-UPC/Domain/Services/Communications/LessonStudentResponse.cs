using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;

namespace TPC_UPC.Domain.Services.Communications
{
    public class LessonStudentResponse : BaseResponse<LessonStudent>
    {
        public LessonStudentResponse(LessonStudent resource) : base(resource)
        {
        }

        public LessonStudentResponse(string message) : base(message)
        {
        }
    }
}

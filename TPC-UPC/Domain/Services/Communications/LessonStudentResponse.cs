using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domain.Models;

namespace Web.Domain.Services.Communications
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

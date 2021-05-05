using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domain.Models;

namespace Web.Domain.Services.Communications
{
    public class LessonResponse : BaseResponse<Lesson>
    {
        public LessonResponse(Lesson resource) : base(resource)
        {
        }

        public LessonResponse(string message) : base(message)
        {
        }
    }
}

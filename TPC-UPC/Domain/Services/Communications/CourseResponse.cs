using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domain.Models;

namespace Web.Domain.Services.Communications
{
    public class CourseResponse : BaseResponse<Course>
    {
        public CourseResponse(Course resource) : base(resource)
        {
        }

        public CourseResponse(string mensaje) : base(mensaje)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domain.Models;

namespace Web.Domain.Services.Communications
{
    public class UserCourseResponse : BaseResponse<UserCourse>
    {
        public UserCourseResponse(UserCourse resource) : base(resource)
        {
        }

        public UserCourseResponse(string mensaje) : base(mensaje)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;

namespace TPC_UPC.Domain.Services.Communications
{
    public class UserCourseResponse : BaseResponse<UserCourse>
    {
        public UserCourseResponse(UserCourse resource) : base(resource)
        {
        }

        public UserCourseResponse(string message) : base(message)
        {
        }
    }
}

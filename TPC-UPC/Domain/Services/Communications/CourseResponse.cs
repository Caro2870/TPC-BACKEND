using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;

namespace TPC_UPC.Domain.Services.Communications
{
    public class CourseResponse : BaseResponse<Course>
    {
        public CourseResponse(Course resource) : base(resource)
        {
        }

        public CourseResponse(string message) : base(message)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;

namespace TPC_UPC.Domain.Services.Communications
{
    public class CareerCourseResponse : BaseResponse<CareerCourse>
    {
        public CareerCourseResponse(CareerCourse resource) : base(resource)
        {
        }

        public CareerCourseResponse(string message) : base(message)
        {
        }
    }
}

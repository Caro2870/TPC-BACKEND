using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    public class CareerCourseResource
    {
        public CourseResource Course { get; set; }
        public CareerResource Career { get; set; }
    }
}

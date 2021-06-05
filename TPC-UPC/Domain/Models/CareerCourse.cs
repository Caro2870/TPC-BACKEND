using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Domain.Models
{
    public class CareerCourse
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int CareerId { get; set; }
        public Career Career { get; set; }
    }
}

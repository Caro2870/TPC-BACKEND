using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Domain.Models
{
    public class Career
    {
        public int Id;
        public string CareerName { get; set; }

        public IList<Student> Students { get; set; } = new List<Student>();

        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        public List<CareerCourse> CareerCourses { get; set; }
    }
}

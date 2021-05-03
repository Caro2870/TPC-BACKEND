using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace TPC_UPC.Domain.Models
{
    public class Course
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public List<UserCourse> UserCourses { get; set; }
    }
}

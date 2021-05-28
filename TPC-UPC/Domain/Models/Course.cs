using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace TPC_UPC.Domain.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Credits { get; set; }

        public IList<Lesson> Lessons { get; set; } = new List<Lesson>();
        public List<UserCourse> UserCourses { get; set; }
    }
}

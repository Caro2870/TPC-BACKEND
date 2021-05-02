using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Domain.Models
{
    public class Lesson
    {
        public int Id { get; set; }

        public int TutorId { get; set; }
        public Tutor Tutor { get; set; }

        public int LessonTypeId { get; set; } 
        public LessonType LessonType { get; set; }
        
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int Vacants { get; set; }

        public List<LessonStudent> LessonStudents = new List<LessonStudent>();
    }
}

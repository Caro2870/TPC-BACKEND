using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Domain.Models
{
    public class LessonStudent
    {
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public string Topic { get; set; }
        public string Comment { get; set; }
        public int Qualification { get; set; }
        public bool Complaint { get; set; }
        public bool Assistance { get; set; }
    }
}

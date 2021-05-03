using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    public class LessonStudentResource
    {
        public LessonResource Lesson { get; set; }
        public StudentResource Student { get; set; }
        public string Topic { get; set; }
        public string Comment { get; set; }
        public int Qualification { get; set; }
        public bool Complaint { get; set; }
        public bool Assistance { get; set; }
    }
}

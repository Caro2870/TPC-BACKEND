using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    public class LessonResource : MeetingResource
    {
        public TutorResource Tutor { get; set; }
        public LessonTypeResource LessonType { get; set; }
        public CourseResource Course { get; set; }
        public int Vacants;
    }
}

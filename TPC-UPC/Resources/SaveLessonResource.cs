using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    public class SaveLessonResource : SaveMeetingResource
    {
        [Required]
        public int TutorId { get; set; }

        [Required]
        public int LessonTypeId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public int Vacants;
    }
}

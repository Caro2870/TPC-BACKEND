using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    public class SaveCareerCourseResource
    {
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int CareerId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    public class SaveCourseResource
    {
        [Required]
        [MaxLength(100)]
        public string CourseName { get; set; }
    }
}

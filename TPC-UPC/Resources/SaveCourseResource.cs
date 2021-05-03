using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Resources
{
    public class SaveCourseResource
    {
        [Required]
        [MaxLength(50)]
        public String Name { get; set; }
    }
}

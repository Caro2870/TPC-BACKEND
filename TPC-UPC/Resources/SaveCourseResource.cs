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
        public string Name { get; set; }

        [Required]
        public int Credits { get; set; }
    }
}

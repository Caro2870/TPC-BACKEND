using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Resources
{
    public class SaveLessonTypeResource
    {
        [Required]
        [MaxLength(50)]
        public String Name { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    public class SaveLessonTypeResource
    {
        [Required]
        [MaxLength(100)]
        public string LessonTypeName { get; set; }
        
        [Required]
        public int StudentsQuantity { get; set; }
    }
}

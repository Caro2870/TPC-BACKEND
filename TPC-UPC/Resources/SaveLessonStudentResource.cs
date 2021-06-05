using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    public class SaveLessonStudentResource
    {
        [Required]
        public int LessonId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [MaxLength(200)]
        public string Topic { get; set; }

        [MaxLength(500)]
        public string Comment { get; set; }

        public int Qualification { get; set; }

        public bool Complaint { get; set; }
        
        public bool Assistance { get; set; }
    }
}

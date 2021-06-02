using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    public class SaveTrainingTutorResource
    {
        [Required]
        public int TrainingId { get; set; }
        [Required]
        public int TutorId { get; set; }
        [Required]
        public bool Assistance{ get; set; }
    }
}

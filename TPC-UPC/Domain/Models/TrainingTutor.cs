using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Domain.Models
{
    public class TrainingTutor
    {
        public int TrainingId { get; set; }
        public Training Training { get; set; }

        public int TutorId { get; set; }
        public Tutor Tutor { get; set; }

        public bool Assistance { get; set; }
    }
}

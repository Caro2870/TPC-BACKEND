using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    public class TrainingTutorResource
    {
        public TrainingResource Trainning { get; set; }
        public TutorResource Tutor { get; set; }
        public bool Assistance { get; set; }
    }
}

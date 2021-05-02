using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Domain.Models
{
    public class Training
    {
        public int Id { get; set; }

        public int CoordinatorId { get; set; }
        public Coordinator Coordinator { get; set; }

        public List<TrainingTutor> TrainingTutors = new List<TrainingTutor>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Domain.Models
{
    public class Tutor : User
    {

        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        public IList<TrainingTutor> TrainingTutors { get; set; } = new List<TrainingTutor>();
        public IList<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
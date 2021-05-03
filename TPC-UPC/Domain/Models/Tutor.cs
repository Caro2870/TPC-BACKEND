using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace Web.Domain.Models
{
    public class Tutor : User
    {
=======
namespace TPC_UPC.Domain.Models
{
    public class Tutor : User
    {

        public int FacultiesId { get; set; }
        public Faculty Faculty { get; set; }

        public List<TrainingTutor> TrainingTutors { get; set; }
        public IList<Lesson> Lessons { get; set; } = new List<Lesson>();
>>>>>>> feature/mapping
    }
}

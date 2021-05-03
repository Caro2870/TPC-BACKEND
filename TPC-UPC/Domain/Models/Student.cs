using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace Web.Domain.Models
{
    public class Student : User
    {
        public int CycleNumber { get; set; }
=======
namespace TPC_UPC.Domain.Models
{
    public class Student : User
    {

        public int CycleNumber { get; set; }

        public int CareerId { get; set; }
        public Career Career { get; set; }

        public List<LessonStudent> LessonStudents { get; set; }
>>>>>>> feature/mapping
    }
}

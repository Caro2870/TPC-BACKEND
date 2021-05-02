using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Domain.Models
{
    public class Coordinator
    {
        //PKFK ?? REVISAR
        //ES LAS DOS COSAS P
        public int Id { get; set; }
        public User User { get; set; }


        //fK
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        public List<Training> Trainings = new List<Training>();


    }
}

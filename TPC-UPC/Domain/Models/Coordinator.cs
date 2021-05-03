using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Domain.Models
{
    public class Coordinator : User
    {
        //fK
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        //uno muchos mensajes
        public IList<MailMessage> MailMessages  { get; set; } = new List<MailMessage>();
        public IList<Training> Trainings = new List<Training>();



    }
}

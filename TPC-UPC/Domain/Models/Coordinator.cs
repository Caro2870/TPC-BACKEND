using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Domain.Models
{
    public class Coordinator
    {
        //PKFK ?? REVISAR
        public int Id { get; set; }
        public User User { get; set; }


        //fK
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        //uno muchos mensajes
        public IList<MailMessage> MailMessages  { get; set; } = new List<MailMessage>();




    }
}

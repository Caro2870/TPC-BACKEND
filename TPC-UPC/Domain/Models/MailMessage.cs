using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Domain.Models
{
    public class MailMessage
    {
        public int Id { get; set; }
                
        public string Message { get; set; }
        public string DocumentLink { get; set; }


        //pk coordinator
        public int CoordinatorId { get; set; }
        public Coordinator Coordinator { get; set; }
        
    }
}

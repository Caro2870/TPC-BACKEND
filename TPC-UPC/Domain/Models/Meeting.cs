using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace Web.Domain.Models
=======
namespace TPC_UPC.Domain.Models
>>>>>>> feature/mapping
{
    public class Meeting
    {
        public int Id { get; set; }
<<<<<<< HEAD
        public String Description { get; set; }
        public String MeetingLink { get; set; }
        public String ResourceLink { get; set; }
=======
>>>>>>> feature/mapping

        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

<<<<<<< HEAD
=======
        public string Description { get; set; }
        public string MeetingLink { get; set; }
        public string ResourceLink { get; set; }
>>>>>>> feature/mapping
    }
}

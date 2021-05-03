using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Domain.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public String MeetingLink { get; set; }
        public String ResourceLink { get; set; }

        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

    }
}

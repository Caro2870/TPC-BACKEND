using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Resources
{
    public class MeetingResource
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public String MeetingLink { get; set; }
        public String ResourceLink { get; set; }

        public ScheduleResource Schedule { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    public abstract class MeetingResource
    {
        public int Id { get; set; }
        public ScheduleResource Shedule { get; set; }
        public string Description { get; set; }
        public string MeetingLink { get; set; }
        public string ResourceLink { get; set; }
    }
}

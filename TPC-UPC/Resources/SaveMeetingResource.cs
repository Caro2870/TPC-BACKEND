using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    public abstract class SaveMeetingResource
    {
        [Required]
        public int ScheduleId { get; set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; set; }
        [Required]
        [MaxLength(100)]
        public string MeetingLink { get; set; }
        [Required]
        [MaxLength(100)]
        public string ResourceLink { get; set; }
    }
}

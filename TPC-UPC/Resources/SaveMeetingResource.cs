using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Resources
{
    //No se si se crea esta clase
    public class SaveMeetingResource
    {
        [Required]
        public String Description { get; set; }
        [Required]
        public String MeetingLink { get; set; }
        [Required]
        public String ResourceLink { get; set; }

        //No se si va este atributo
        public ScheduleResource Schedule { get; set; }
    }
}

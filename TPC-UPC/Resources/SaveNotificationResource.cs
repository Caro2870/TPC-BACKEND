using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    public class SaveNotificationResource
    {
        public string Link { get; set; }
        public DateTime SendDate { get; set; }
        public int NotificationTypeId { get; set; }
    }
}

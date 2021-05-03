using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    public class NotificationResource
    {
        public int Id { get; set; }
        public NotificationTypeResource NotificationType { get; set; }
        public string Link { get; set; }
        public DateTime SendDate { get; set; }
    }
}

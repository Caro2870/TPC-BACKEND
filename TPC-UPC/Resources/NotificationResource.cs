using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;

namespace TPC_UPC.Resources
{
    public class NotificationResource
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public DateTime SendDate { get; set; }
        public NotificationTypeResource NotificationType { get; set; }
        //public int NotificationTypeId { get; set; }
        //public string NotificationTypeDescription { get; set; }

    }
}

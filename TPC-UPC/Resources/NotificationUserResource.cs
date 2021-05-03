using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    public class NotificationUserResource
    {
        public NotificationResource Notification { get; set; }
        public UserResource User { get; set; }
    }
}

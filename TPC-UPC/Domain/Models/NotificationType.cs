using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Domain.Models
{
    public class NotificationType
    {
        public int Id { get; set;  }
        public string Description { get; set; }
        public IList<Notification> Notifications { get; set; } = new List<Notification>();
    }
}

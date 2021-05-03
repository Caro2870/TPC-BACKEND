using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    public class SaveNotificationResource
    {
        [Required]
        public int NotificationTypeId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Link;
        
        [Required]
        public DateTime SendDate { get; set; }
    }
}

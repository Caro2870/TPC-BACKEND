using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;

namespace TPC_UPC.Domain.Services.Communications
{
    public class NotificationResponse : BaseResponse<Notification>
    {
        public NotificationResponse(Notification resource) : base(resource)
        {
        }

        public NotificationResponse(string message) : base(message)
        {
        }
    }
}

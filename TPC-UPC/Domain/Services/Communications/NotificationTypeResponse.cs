using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;

namespace TPC_UPC.Domain.Services.Communications
{
    public class NotificationTypeResponse : BaseResponse<NotificationType>
    {
        public NotificationTypeResponse(NotificationType resource) : base(resource)
        {
        }

        public NotificationTypeResponse(string message) : base(message)
        {
        }
    }
}

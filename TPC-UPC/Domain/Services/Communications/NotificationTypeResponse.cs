using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domain.Models;

namespace Web.Domain.Services.Communications
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

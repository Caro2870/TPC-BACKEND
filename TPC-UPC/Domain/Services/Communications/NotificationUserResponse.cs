using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domain.Models;

namespace Web.Domain.Services.Communications
{
    public class NotificationUserResponse : BaseResponse<NotificationUser>
    {
        public NotificationUserResponse(NotificationUser resource) : base(resource)
        {
        }

        public NotificationUserResponse(string message) : base(message)
        {
        }
    }
}

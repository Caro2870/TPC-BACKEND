using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domain.Models;

namespace Web.Domain.Services.Communications
{
    public class MailMessageResponse : BaseResponse<MailMessage>
    {
        public MailMessageResponse(MailMessage resource) : base(resource)
        {
        }

        public MailMessageResponse(string message) : base(message)
        {
        }
    }
}

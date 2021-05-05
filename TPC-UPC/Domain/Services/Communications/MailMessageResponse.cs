using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;

namespace TPC_UPC.Domain.Services.Communications
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

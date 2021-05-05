using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domain.Models;

namespace Web.Domain.Services.Communications
{
    public class MeetingResponse : BaseResponse<Meeting>
    {
        public MeetingResponse(Meeting resource) : base(resource)
        {
        }

        public MeetingResponse(string message) : base(message)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domain.Models;

namespace Web.Domain.Services.Communications
{
    public class SuggestionResponse : BaseResponse<Suggestion>
    {
        public SuggestionResponse(Suggestion resource) : base(resource)
        {
        }

        public SuggestionResponse(string message) : base(message)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;

namespace TPC_UPC.Domain.Services.Communications
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

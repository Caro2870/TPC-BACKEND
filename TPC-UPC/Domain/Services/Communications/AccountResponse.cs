using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domain.Models;

namespace Web.Domain.Services.Communications
{
    public class AccountResponse : BaseResponse<Account>
    {
        public AccountResponse(Account resource) : base(resource)
        {
        }

        public AccountResponse(string message) : base(message)
        {
        }
    }
}

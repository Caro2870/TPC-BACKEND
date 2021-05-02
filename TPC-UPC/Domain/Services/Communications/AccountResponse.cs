using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;

namespace TPC_UPC.Domain.Services.Communications
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

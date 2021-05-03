using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    public abstract class UserResource
    {
        public int Id { get; set; }
        public AccountResource Account { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public long PhoneNumber { get; set; }

    }
}

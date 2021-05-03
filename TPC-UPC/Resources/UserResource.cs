using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Mail { get; set; }
        public long PhoneNumber { get; set; }

        //Student
        public int CycleNumber { get; set; }

    }
}

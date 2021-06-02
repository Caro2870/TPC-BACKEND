using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    public class CareerResource
    {
        public int Id { get; set; }
        public string CareerName { get; set; }

        FacultyResource faculty { get; set; }
    }
}

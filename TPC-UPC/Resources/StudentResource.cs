using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    public class StudentResource : UserResource
    {
        public int CycleNumber { get; set; }
        public CareerResource CareerResource { get; set; }
    }
}

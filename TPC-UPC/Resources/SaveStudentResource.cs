using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    public class SaveStudentResource : SaveUserResource
    {
        public int CycleNumber { get; set; }
        public int CareerId { get; set; } //duda
    }
}

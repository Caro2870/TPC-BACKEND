using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Domain.Models
{
    public class Student : User
    {
        public int CycleNumber { get; set; }
    }
}

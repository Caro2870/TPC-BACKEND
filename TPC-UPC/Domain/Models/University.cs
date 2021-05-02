using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Domain.Models
{
    public class University
    {
        public int Id { get; set; }
        public string UniversityName { get; set; }

        //relacion uno

        public Account Account { get; set; }
        
    }
}

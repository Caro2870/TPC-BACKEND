using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    public class SaveCareerResource
    {
        [MaxLength(100)]
        public string CareerName { get; set; }
    }
}

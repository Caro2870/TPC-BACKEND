using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    public class SaveTrainningResource
    {
        [Required]
        public int CoordinatorId { get; set; }
    }
}

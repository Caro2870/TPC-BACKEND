using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    public class SaveMailMessageResource
    {
        [Required]
        [StringLength(500)]
        public string message { get; set; }
        [Required]
        [StringLength(200)]
        public string documentlink { get; set; }
    }
}

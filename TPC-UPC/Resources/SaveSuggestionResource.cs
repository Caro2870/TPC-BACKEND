using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace TPC_UPC.Resources
{
    public class SaveSuggestionResource
    {

        [Required]
        [StringLength(500)]
        public string Message { get; set; }
    }
}

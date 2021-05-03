using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    public class SaveAccountResource
    {
        [Required]
        [StringLength(50)]
        public string AccountName { get; set; } //dudas
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Password { get; set; }  //dudas

        [Required]
        public int UniversityId { get; set; }
    }
}

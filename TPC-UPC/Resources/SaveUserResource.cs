using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Resources
{
    public class SaveUserResource
    {
        [Required]
        [MaxLength(30)]
        public String FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public String LastName { get; set; }
        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public String Mail { get; set; }
        [MaxLength(15)]
        [Phone]
        public long PhoneNumber { get; set; }

        //Student
        public int CycleNumber { get; set; }
    }
}

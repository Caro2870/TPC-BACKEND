using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;

namespace TPC_UPC.Resources
{
    public class AccountResource
    {
        public int Id { get; set; }
        public string AccountName { get; set; } //dudas
        public string Password { get; set; }  //dudas
        //public int UniversityId { get; set; }
        public UniversityResource University { get; set; }
    }
}

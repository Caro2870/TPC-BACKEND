using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Resources
{
    //muestra 
    public class AccountResource
    {
        public int Id { get; set; }
        public string AccountName { get; set; } //dudas
        public string Password { get; set; }  //dudas
        public UniversityResource University { get; set; }
    }
}

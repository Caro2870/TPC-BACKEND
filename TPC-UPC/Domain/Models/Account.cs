using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Domain.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string Password { get; set; }

        //uno-FK
        public string UniversityId { get; set; }
        public University University { get; set; }

        //uno a
        public User User { get; set; }

    }
}

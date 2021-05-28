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

        public IList<Account> Accounts { get; set; } = new List<Account>();


        /*public int AccountId { get; set; }
        public Account Account { get; set; }*/

    }
}

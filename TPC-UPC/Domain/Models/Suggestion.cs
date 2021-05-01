using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Domain.Models
{
    public class Suggestion
    {
        public int Id { get; set; }
        public string Message { get; set; }

        // Fk USER
        public int UserId { get; set; }
        public User User { get; set; }

        
    }
}

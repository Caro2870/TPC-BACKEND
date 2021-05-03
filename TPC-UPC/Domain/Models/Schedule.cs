using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace Web.Domain.Models
=======
namespace TPC_UPC.Domain.Models
>>>>>>> feature/mapping
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
<<<<<<< HEAD

        public IList<Meeting> Meetings = new List<Meeting>();
=======
>>>>>>> feature/mapping
    }
}

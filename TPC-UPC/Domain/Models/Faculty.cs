using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Domain.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public IList<Coordinator> Coordinators { get; set; } = new List<Coordinator>();
        public IList<Tutor> Tutors { get; set; } = new List<Tutor>();

        public IList<Career> Careers { get; set; } = new List<Career>();

        public int UniversityId { get; set; }
        public University University { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Domain.Models
{
    public class LessonType
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Quantity { get; set; }

        //Add relationship
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Domain.Models
{
    public class LessonType
    {
        public int Id { get; set; }
        public string LessonTypeName { get; set; }
        public int StudentsQuantity { get; set; }

        public IList<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}

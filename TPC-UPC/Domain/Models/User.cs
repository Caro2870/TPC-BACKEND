using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_UPC.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }


        //un user tiene un account //FK
        public int AccountId { get; set; }
        public Account Account { get; set; }

        // un User tiene MUCHOS suggestion 
        public IList<Suggestion> Suggestions { get; set; } = new List<Suggestion>();

        public List<UserCourse> UserCourses { get; set; }

        public List<NotificationUser> NotificationUsers { get; set; }

    }
}

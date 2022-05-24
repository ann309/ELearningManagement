using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.DAL.Models
{
    public class UserInformation : IdentityUser
    {
        //public UserInformation()
        //{
        //    Chats = new HashSet<Chat>();
        //}

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<Upload> Uploads { get; set; }
        public virtual ICollection<Calender> CalenderEvents { get; set; }





    }
}

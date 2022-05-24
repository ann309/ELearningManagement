using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.DAL.Models
{
    public class Chat
    {
        public int ID { get; set; }

        [Required]
        public DateTime SentAt { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public string RecieverName { get; set; }
       // public virtual UserInformation Sender { get; set; }

        



    }
}

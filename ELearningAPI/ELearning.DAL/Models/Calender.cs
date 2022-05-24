using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.DAL.Models
{
    public class Calender
    {
        public int ID { get; set; }

        [Required]
        public string Event { get; set; }

        [Required]
        public DateTime EventStart { get; set; }

        [Required]
        public DateTime EventEnd { get; set; }

        //[Column(TypeName = "nvarchar(Max)")]
        //public string Color { get; set; }

        [Required]
        public string Location { get; set; }

        public string UserID { get; set; }
        public virtual UserInformation User { get; set; }
    }
}

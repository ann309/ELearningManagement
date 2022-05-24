using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.DAL.Models
{
    [Table("Students")]
    public class Student :UserInformation
    {
       // [Key]
        //public int StudentID { get; set; }

        //public UserInformation StudentUser { get; set; }

        //public int AssignedID { get; set; }

        //public string StudentGUID { get; set; }
        //[ForeignKey("StudentGUID")]
        //public UserInformation UserInformation { get; set; }
        public string Class { get; set; }



    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.DAL.Models
{
    [Table("Faculties")]
    public class Faculty :UserInformation
    {

        //[Key]
       // public int FacultyID { get; set; }

        //public UserInformation FacultyUser { get; set; }

        public string Subject { get; set; }
        public string Designation { get; set; }

        //public string FacultyGUID { get; set; }
        //[ForeignKey("StudentGUID")]
        //public UserInformation UserInformation { get; set; }

        


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.DAL.Models
{
    public class Upload
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string FileType { get; set; }

        [Required]
        public string Extension { get; set; }


        public string Description { get; set; }

        [Required]
        public string UploadedBy { get; set; }

        [Required]
        public DateTime? CreatedOn { get; set; }


        [Required]
        public string FilePath { get; set; }

        public string UserID { get; set; }
        public virtual UserInformation User { get; set; }

        //public int? DocumentationID { get; set; }
        //public virtual Documentation Documents { get; set; }

        //public int? ProjectID { get; set; }
        //public virtual Project Projects { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.DAL.Models
{
     public class Documentation
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        //public virtual ICollection<Upload> Uploads { get; set; }


    }
}

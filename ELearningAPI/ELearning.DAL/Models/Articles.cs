using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.DAL.Models
{
    public class Articles
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Link { get; set; }
    }
}

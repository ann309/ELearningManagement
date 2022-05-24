using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.DAL.Models
{
    public class Assigned
    {
        [Key]
        public int ID { get; set; }

        public string? AssignedTo { get; set; }
        [ForeignKey("AssignedTo")]
        public Student Student { get; set; }

        public string? AssignedBy { get; set; }
        [ForeignKey("AssignedBy")]
        public Faculty Faculty { get; set; }


        [ForeignKey("ProjectId")]
        public int? ProjectId { get; set; }
        public Project Project { get; set; }

        [AllowNull]
        [ForeignKey("DocumentationId")]
        public int? DocumentationId { get; set; }
        public Documentation Documentation { get; set; }

        public int? UploadId { get; set; }
        [ForeignKey("UploadId")]
        public Upload Upload { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignement_2.Models
{
    public class Department
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [ForeignKey("Instructor")]
        public int Ins_ID { get; set; }
        public Instructor Instructor { get; set; }

        public DateTime HiringDate { get; set; }
    }
}

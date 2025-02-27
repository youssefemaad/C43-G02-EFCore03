using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignement_2.Models
{
    public class Topic
    {
        [Key, Column("TopicID", TypeName = "int")]
        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string? Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Assignement_2.Models
{
    public class Course_Inst
    {
        public int Inst_ID { get; set; }
        public int Course_ID { get; set; }
        public string? Evaluate { get; set; }

        // Navigation properties
        public Instructor Instructor { get; set; }
        public Course Course { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignement_2.Models
{
    public class Instructor
    {
        [Key]
        public int Inst_ID { get; set; }
        public string Name { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<Course_Inst> CourseInstructors { get; set; }
    }
}

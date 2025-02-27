using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignement_2.Models
{
    public class Student_Course
    {
        public int Student_ID { get; set; }
        public int Course_ID { get; set; }
        public string? Grade { get; set; }

        // Navigation properties
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
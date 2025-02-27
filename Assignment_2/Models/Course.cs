using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignement_2.Models
{
    public class Course
    {
        public int ID { get; set; }
        public int Duration { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Top_ID { get; set; }

        // Navigation properties
        public Topic Topic { get; set; }
        public ICollection<Student_Course> StudentCourses { get; set; }
        public ICollection<Course_Inst> CourseInstructors { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignement_2.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? Address { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }

        // Navigation properties
        public Department Department { get; set; }
        public ICollection<Student_Course> StudentCourses { get; set; }
    }
}

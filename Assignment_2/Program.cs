using System;
using System.Linq;
using System.Text;
using Assignement_2.DdContext;
using Assignement_2.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Assignement_2
{
    class Program
    {
        static void Main(string[] args)
        {
            using ItiDbContext dbContext = new ItiDbContext();

            #region Insert Data
            var students = new List<Student>
            {
                new Student { ID = 1, FName = "John", LName = "Doe", Address = "123 Elm St", Age =20, DepartmentId = 10 },
                new Student { ID = 2, FName = "Jane", LName = "Smith", Address = "456 Oak St", Age = 21, DepartmentId = 20 }
            };

            var courses = new List<Course>
            {
                new Course { ID = 100 , Duration = 20, Name = "Math", Description = "Mathematics", Top_ID = 1000 },
                new Course { ID = 200 , Duration = 30, Name = "Science", Description = "Science", Top_ID = 2000 }
            };

            var instructors = new List<Instructor>
            {
                new Instructor {Inst_ID = 1, Name = "Dr. Brown" },
                new Instructor {Inst_ID = 2, Name = "Prof. Green" }
            };

            var departments = new List<Department>
            {
                new Department { ID = 10, Name = "CS", Inst_ID = 1 , HiringDate = DateTime.Now },
                new Department { ID = 20, Name = "IT", Inst_ID = 2 , HiringDate = DateTime.Now }
            };

            var studentCourses = new List<Student_Course>
            {
                new Student_Course { StudentId = 1, CourseId = 100, Grade = 80 },
                new Student_Course { StudentId = 2, CourseId = 200, Grade = 90 }
            };


            var courseInstructors = new List<Course_Inst>
            {
                new Course_Inst { CourseId = 100, InstId = 1, Evaluate = "Good" },
                new Course_Inst { CourseId = 200, InstId = 2, Evaluate = "Excellent" }
            };

            dbContext.Students.AddRange(students);
            dbContext.Courses.AddRange(courses);
            dbContext.Instructors.AddRange(instructors);
            dbContext.Departments.AddRange(departments);
            dbContext.StudentCourses.AddRange(studentCourses);
            dbContext.CourseInstructors.AddRange(courseInstructors);

            dbContext.SaveChanges();
            #endregion

            #region Update Data
            // Update example
            var studentToUpdate = dbContext.Students.FirstOrDefault(s => s.FName == "John");
            if (studentToUpdate != null)
            {
                studentToUpdate.LName = "UpdatedDoe";
                dbContext.SaveChanges();
            }
            #endregion

            #region Delete Data
            // Delete example
            var studentToDelete = dbContext.Students.FirstOrDefault(s => s.FName == "Jane");
            if (studentToDelete != null)
            {
                dbContext.Students.Remove(studentToDelete);
                dbContext.SaveChanges();
            }
            #endregion

            #region Select Data
            // Select example
            var allStudents = dbContext.Students.ToList();
            foreach (var student in allStudents)
            {
                Console.WriteLine($"{student.FName} {student.LName}");
            }
            #endregion

            #region Retrieve Data with Eager Loading
            // Eager loading example
            var studentsWithCourses = dbContext.Students
                .Include(s => s.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .ToList();

            foreach (var student in studentsWithCourses)
            {
                Console.WriteLine($"{student.FName} {student.LName} is enrolled in:");
                foreach (var sc in student.StudentCourses)
                {
                    Console.WriteLine($" - {sc.Course.Name}");
                }
            }
            #endregion

            #region Retrieve Data with Lazy Loading
            // Lazy loading example
            var lazyStudent = dbContext.Students.FirstOrDefault(s => s.FName == "John");
            if (lazyStudent != null)
            {
                Console.WriteLine($"{lazyStudent.FName} {lazyStudent.LName} is enrolled in:");
                foreach (var sc in lazyStudent.StudentCourses)
                {
                    Console.WriteLine($" - {sc.Course.Name}");
                }
            }
            #endregion
        }
    }
}
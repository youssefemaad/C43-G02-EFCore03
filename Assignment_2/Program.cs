using System;
using System.Linq;
using System.Collections.Generic;
using Assignement_2.DdContext;
using Assignement_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignement_2
{
    class Program
    {
        static void Main(string[] args)
        {
            using ItiDbContext dbContext = new ItiDbContext();

            #region Insert Data
            Student students = new Student { FName = "Ahmed", LName = "Ali", Address = "Cairo", Age = 20, DepartmentId = 1 };


            Course courses = new Course { Duration = 20, Name = "Math", Description = "Mathematics", Top_ID = 1000 };


            Instructor instructors = new Instructor { Name = "Dr. Brown" };

            Department departments = new Department { Name = "CS", Ins_ID = 1, HiringDate = DateTime.Now };

            dbContext.Students.Add(students);
            dbContext.Courses.AddRange(courses);
            dbContext.Instructors.AddRange(instructors);
            dbContext.Departments.AddRange(departments);
            dbContext.SaveChanges();

            Student_Course studentCourses = new Student_Course { Student_ID = students.ID, Course_ID = courses.ID, Grade = "Good" };
            Course_Inst course_inst = new Course_Inst { Course_ID = courses.ID, Inst_ID = instructors.Inst_ID, Evaluate = "Good" };

            dbContext.StudentCourses.Add(studentCourses);
            dbContext.CourseInstructors.Add(course_inst);
            dbContext.SaveChanges();

            #endregion

            #region Retrieve Data with Eager Loading
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

            #region Retrieve Data with Explicit Loading

            var studentsWithCoursesExplicit = dbContext.Students.ToList();

            foreach (var student in studentsWithCoursesExplicit)
            {
                dbContext.Entry(student)
                    .Collection(s => s.StudentCourses)
                    .Query()
                    .Include(sc => sc.Course)
                    .Load();

                Console.WriteLine($"{student.FName} {student.LName} is enrolled in:");
                foreach (var sc in student.StudentCourses)
                {
                    Console.WriteLine($" - {sc.Course.Name}");
                }
            }
            #endregion
        }
    }
}

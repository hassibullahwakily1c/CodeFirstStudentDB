using System;
using System.Data.Entity;
using System.Linq;

namespace CodeFirstStudentDatabase
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
    }

    public class StudentContext : DbContext
    {
        public StudentContext() : base("StudentDatabase")
        {
        }

        public DbSet<Student> Students { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new StudentContext())
            {
                var student = new Student
                {
                    StudentName = "Alex Johnson"
                };

                db.Students.Add(student);
                db.SaveChanges();

                Console.WriteLine("Student was successfully added to the database.");
                Console.WriteLine();

                var students = db.Students.ToList();

                foreach (var item in students)
                {
                    Console.WriteLine("Student ID: " + item.StudentId);
                    Console.WriteLine("Student Name: " + item.StudentName);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to close the program.");
            Console.ReadKey();
        }
    }
}
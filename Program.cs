using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;

namespace StudentInfoSystem //this is the assembly
{
    public class VariableChecker
    {
        public string NameChecker(string studentName)
        {
            while (String.IsNullOrEmpty(studentName) || !(Regex.IsMatch(studentName, @"^[a-zA-Z ]+$")))
            {
                Console.WriteLine("Please make sure that input doesn't contain unnecessary characters or left blank.");
                Console.Write("Enter student's name: ");
                studentName = Console.ReadLine();
            }

            return studentName;
        }

        public int AgeChecker(string studentAge)
        {

            while (String.IsNullOrEmpty(studentAge) || !(Int32.TryParse(studentAge, out _)))
            {
                Console.WriteLine("Please make sure that you entered your age, numerically.");
                Console.Write("Enter student's age: ");
                studentAge = Console.ReadLine();
            }

            while(Int32.Parse(studentAge) < 0)
            {
                Console.WriteLine("Please make sure that age is valid. negative value not allowed");
                Console.Write("Enter student's age: ");
                studentAge = Console.ReadLine();
            }

            return Int32.Parse(studentAge);
        }

        public double GradeChecker(string studentGrade)
        {

            while (String.IsNullOrEmpty(studentGrade) || !(Double.TryParse(studentGrade, out _)))
            {
                Console.WriteLine("Please make sure that you entered your age, numerically.");
                Console.Write("Enter student's age: ");
                studentGrade = Console.ReadLine();
            }

            while (Double.Parse(studentGrade) < 0)
            {
                Console.WriteLine("Please make sure that age is valid. negative value not allowed");
                Console.Write("Enter student's age: ");
                studentGrade = Console.ReadLine();
            }

            return Double.Parse(studentGrade);
        }

        public bool inputSystemAgain(string reInput)
        {
            bool inputAgain = false;

            while (!(reInput.ToLower() == "yes") && !(reInput.ToLower() == "no"))
            {
                Console.WriteLine("Invalid input. Enter only yes or no on the space provided.");
                Console.Write("Do you want to input more? (yes/no): ");
                reInput = Console.ReadLine();
            }

            switch (reInput)
            {
                case "yes":
                    inputAgain = true;
                    break;
                case "no":
                    inputAgain = false;
                    break;
                default:
                    break;
            }
            return inputAgain;
        }
    }

    public class Student
    {
        private string _studentName;
        private int _studentAge;
        private double _studentGrade;

        public string StudentName 
        {
            get { return _studentName; }
            set { _studentName = value; }
        }

        public int StudentAge
        {
            get { return _studentAge; }
            set
            {
                if (value >= 0 || value <= 100)
                {
                    _studentAge = value;
                }
                else
                {
                    _studentGrade = 100;
                }
            }
        }

        public double StudentGrade
        {
            get { return _studentGrade; }
            set 
            { 
                if (value >= 0 || value <= 100 )
                {
                    _studentGrade = value;
                }
                else
                {
                    _studentGrade = 100;
                }
             }
        }
    }

    public class StudentManagement
    {
        private List<Student> _students = new List<Student>();

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }
        public void DisplayStudentInfo()
        {
            foreach(var student in _students)
            {
                Console.WriteLine("Name: " + student.StudentName);
                Console.WriteLine("Age: " + student.StudentAge);
                Console.WriteLine("Grade: " + student.StudentGrade);
            }
        }
    }

    class Program  // no access modifier because this is what actually runs in application
    {             // but when creating other classes, then it need access modifier
        static void Main(string[] args)
        {
            bool inputAgain = false;
            string reInput;
            Student student = new Student();
            VariableChecker checker = new VariableChecker();
            StudentManagement studentManagement = new StudentManagement();

            do
            {
                //prompts for user to input student info
                Console.Write("Enter student's name: ");
                student.StudentName = checker.NameChecker(Console.ReadLine());

                Console.Write("\nEnter student's age: ");
                student.StudentAge = checker.AgeChecker(Console.ReadLine());

                Console.Write("\nEnter student's grade: ");
                student.StudentGrade = checker.GradeChecker(Console.ReadLine());


                var newStudent = new Student
                {
                    StudentName = student.StudentName,
                    StudentAge = student.StudentAge,
                    StudentGrade = student.StudentGrade
                };

                //put student information on students list
                studentManagement.AddStudent(newStudent);

                //continue input information or not
                Console.Write("Do you want to input more? (yes/no): ");
                inputAgain = checker.inputSystemAgain(Console.ReadLine());


            } while (inputAgain);

            studentManagement.DisplayStudentInfo();

        }
    }
}
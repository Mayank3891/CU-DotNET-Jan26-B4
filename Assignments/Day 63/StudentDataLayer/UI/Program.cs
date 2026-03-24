using System;
using StudentDataLayer.Repository;
using StudentDataLayer.Services;
using StudentDataLayer.Models;

namespace StudentDataLayer.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ENTER YOUR CHOICE :  ");
            Console.WriteLine("CHOOSE \n       1 FOR LIST TYPE \n       2 FOR JSON TYPE");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Using List by default.");
                choice = 1;
            }

            IStudentRepository repository;

            switch (choice)
            {
                case 1:
                    repository = new ListStudentRepository();
                    Console.WriteLine("Using List repository.");
                                break;

                case 2:
                    repository = new JsonStudentRepository();
                    Console.WriteLine("Using JSON repository.");
                    break;

                default:
                    Console.WriteLine("Invalid choice! Using List by default.");
                    repository = new ListStudentRepository();
                    break;
            }

            StudentServices service = new StudentServices(repository);

            while (true)
            {
                Console.WriteLine("\nMenu:\n 1 - Add student\n 2 - Show list\n 3 - Exit");
                Console.Write("Enter choice: ");
                if (!int.TryParse(Console.ReadLine(), out int menuChoice))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                if (menuChoice == 1)
                {
                    try
                    {
                        Console.Write("Id: ");
                        int id = int.TryParse(Console.ReadLine(), out var parsedId) ? parsedId : 0;

                        Console.Write("Name: ");
                        string? name = Console.ReadLine() ?? string.Empty;

                        Console.Write("Grade (0-100): ");
                        double grade = double.TryParse(Console.ReadLine(), out var parsedGrade) ? parsedGrade : -1;

                        var student = new Student { Id = id, Name = name, Grade = grade };
                        service.addstudent(student);
                        Console.WriteLine("Student added successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error adding student: {ex.Message}");
                    }
                }
                else if (menuChoice == 2)
                {
                    var students = service.GetStudents();
                    bool any = false;
                    Console.WriteLine("\nId\tName\tGrade");
                    foreach (var s in students)
                    {
                        any = true;
                        Console.WriteLine($"{s.Id}\t{s.Name}\t{s.Grade}");
                    }
                    if (!any) Console.WriteLine("No students found.");
                }
                else if (menuChoice == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Unknown option.");
                }
            }

            Console.WriteLine("Exiting...");
        }
    }
}

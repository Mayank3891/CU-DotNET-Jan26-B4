using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using StudentDataLayer.Models;

namespace StudentDataLayer.Repository
{
    internal class JsonStudentRepository : IStudentRepository
    {
        private readonly string _filePath = "../../../students.json";

        public void addstudent(Student student)
        { 
            if (student is null) throw new ArgumentNullException(nameof(student));

            var students = ReadAll();
            students.Add(student);
            File.WriteAllText(_filePath, JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true }));
        }

        public IEnumerable<Student> GetStudents() => ReadAll();

        private List<Student> ReadAll()
        {
            if (!File.Exists(_filePath)) return new List<Student>();

            var json = File.ReadAllText(_filePath);
            if (string.IsNullOrWhiteSpace(json)) return new List<Student>();

            return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
        }
    }
}

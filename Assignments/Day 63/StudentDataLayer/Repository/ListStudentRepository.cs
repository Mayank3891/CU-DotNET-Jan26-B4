using StudentDataLayer.Models;

namespace StudentDataLayer.Repository
{
    internal class ListStudentRepository : IStudentRepository
    {
        private readonly List<Student> _students = new();

        public void addstudent(Student student)
        {
            if (student is null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            _students.Add(student);
        }

        public IEnumerable<Student> GetStudents() => _students;
    }
}

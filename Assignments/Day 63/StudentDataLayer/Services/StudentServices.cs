using StudentDataLayer.Models;
using StudentDataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataLayer.Services
{
    internal class StudentServices : IStudentServices
    {
        private IStudentRepository _repo { get; set; }
        public StudentServices(IStudentRepository repo)
        {
            _repo = repo;
        }
        public void addstudent(Student student)
        {
            if (student.Grade > 100 || student.Grade < 0)
            {
                throw new ArithmeticException("student marks range should be 0 to 100");

            }
            _repo.addstudent(student);

        }
        public IEnumerable<Student> GetStudents() => _repo.GetStudents();

            
    }
}

using StudentDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataLayer.Services
{
    internal interface IStudentServices
    {
        public void addstudent(Student student);
        public IEnumerable<Student> GetStudents() ;

    }
}

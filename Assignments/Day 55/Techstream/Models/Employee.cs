using System.ComponentModel.DataAnnotations;

namespace Techstream.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        [Range(20000,50000)]
        public double Salary { get; set; }

        public Employee(int Id,string Name,string Position,double Salary)
        {
            this.Id = Id;
            this.Name = Name;
            this.Position = Position;
            this.Salary = Salary;
        }
    }
}

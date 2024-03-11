using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhanVien
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }
        public double salary { get; set; }
        public DateTime brirthday { get; set; }
        public int  Age()
        {
            return DateTime.Today.Year - this.brirthday.Year;
            
        }
        public static List<Employee> getEmployee()
        {

            return new List<Employee>
            {
                new Employee { Id = 1,Name = "N", DepartmentID = 1, salary = 2000, brirthday = new DateTime(2003, 04, 30)},
                new Employee { Id = 2,Name = "A", DepartmentID = 2, salary = 1000, brirthday = new DateTime(2004, 04, 30)},
                new Employee { Id = 3,Name = "B", DepartmentID = 1, salary = 15000, brirthday = new DateTime(2006, 04, 30)},
                new Employee { Id = 4,Name = "C", DepartmentID = 2, salary = 2200, brirthday = new DateTime(2001, 04, 30)},
                new Employee { Id = 5,Name = "D", DepartmentID = 3, salary = 900, brirthday = new DateTime(1999, 04, 30)},
                new Employee { Id = 6,Name = "E", DepartmentID = 1, salary = 1000, brirthday = new DateTime(2003, 04, 30)},
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace QLNhanVien
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = Employee.getEmployee();
            List<Department> list2 = Department.GetDepartments();
            foreach (Employee e in list)
            {
                Console.WriteLine($"ID: {e.Id},Name: {e.Name},Salary: {e.salary},Age: {e.Age()}");
            }
            // Tìm người co salary cao nhất
            Employee maxEmployee = list.OrderByDescending(p => p.salary).First();
            Console.WriteLine("Nguoi co SALARY lan nhat la: " + maxEmployee.Name + ", " + maxEmployee.salary + "$");

            // Tìm người có salary ít nhất
            Employee minEmployee = list.OrderBy(p => p.salary).First();
            Console.WriteLine("Nguoi co SALARY nho nhat la: " + minEmployee.Name + ", " + minEmployee.salary + "$");
            // Tìm người co AGE cao nhất
            Employee maxAge = list.OrderByDescending(p => p.Age()).First();
            Console.WriteLine("Nguoi co AGE cao nhat la: " + maxEmployee.Name + ", " + maxEmployee.Age() + " tuoi");

            // Tìm người có AGE nho nhất
            Employee minAge = list.OrderBy(p => p.Age()).First();
            Console.WriteLine("Nguoi co AGE nho nhat la: " + minEmployee.Name + ", " + minEmployee.Age() + " tuoi");
            // join group theo phong ban
            var query = from department in list2
                        join employee in list
                        on department.Id equals employee.DepartmentID into groupedEmployees
                        select new { Department = department, Employees = groupedEmployees };

            foreach (var de in query)
            {
                Console.WriteLine($"Department: {de.Department.Name}");
                foreach (var e in de.Employees)
                {
                    Console.WriteLine($"ID: {e.Id},Name: {e.Name},Salary: {e.salary},Age: {e.Age()}");
                }
            }
            // left outer join
            Console.WriteLine("Dung left outer join");
            var leftJoinQuery = from department in list2
                                join employee in list
                                on department.Id equals employee.DepartmentID into groupedEmployees
                                from employee in groupedEmployees.DefaultIfEmpty()
                                select new { Department = department, Employee = employee };
            foreach (var e in leftJoinQuery) {
                Console.WriteLine("{0} -{1}", e.Department.Name,e.Employee.Name);
            }
            // Right outer join
            Console.WriteLine("Dung Right outer join");
            var rightJoinQuery = from employee in list
                                 join department in list2
                                 on employee.DepartmentID equals department.Id into groupedDepartments
                                 from department in groupedDepartments.DefaultIfEmpty()
                                 select new { Employee = employee, Department = department };
            foreach (var e in rightJoinQuery)
            {
                Console.WriteLine("{0} -{1}", e.Department.Name, e.Employee.Name);
            }
        }
    }
}

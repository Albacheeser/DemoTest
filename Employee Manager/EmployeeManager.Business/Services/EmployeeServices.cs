using EmployeeManager.Business.Interfaces;
using EmployeeManager.Business.Models;
using EmployeeManager.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Business.Services
{
    public class EmployeeServices: IEmployeeServices
    {
        private readonly ISettings _settings;
        public EmployeeServices(ISettings settings)
        {
            _settings = settings;
        }

        public List<IEmployee> GetWorkForceEmployees()
        {
            var employees = new List<IEmployee>();

            employees.Add(GetNewEmployee((int)EmployeeType.Hourly, "Frank", "A", "Swaddell"));
            employees.Add(GetNewEmployee((int)EmployeeType.Hourly,"Art", null, "Vandalay"));
            employees.Add(GetNewEmployee((int)EmployeeType.Hourly, "John", null, "Cattour"));
            employees.Add(GetNewEmployee((int)EmployeeType.Hourly, "Sean", "N", "French"));
            employees.Add(GetNewEmployee((int)EmployeeType.Hourly, "Will", "P", "Richardson"));
            employees.Add(GetNewEmployee((int)EmployeeType.Hourly, "Martha", null, "Worthy"));
            employees.Add(GetNewEmployee((int)EmployeeType.Hourly, "Shondra", null, "Sykes"));
            employees.Add(GetNewEmployee((int)EmployeeType.Hourly, "Mary", "", "Shelley"));
            employees.Add(GetNewEmployee((int)EmployeeType.Hourly, "Xavior", null, "Cougat"));
            employees.Add(GetNewEmployee((int)EmployeeType.Hourly, "Juliet", null, "Prouse"));
            employees.Add(GetNewEmployee((int)EmployeeType.Hourly, "Joan", "M", "Pickford"));
            employees.Add(GetNewEmployee((int)EmployeeType.Hourly, "Mike", "C", "Shields"));
            employees.Add(GetNewEmployee((int)EmployeeType.Hourly, "Michael", "J", "Bestler"));
            employees.Add(GetNewEmployee((int)EmployeeType.Hourly, "Juan", null, "Ruiz"));

            employees.Add(GetNewEmployee((int)EmployeeType.Salary, "Darrell", null, "Smith"));
            employees.Add(GetNewEmployee((int)EmployeeType.Salary, "Fred", null, "Herring"));
            employees.Add(GetNewEmployee((int)EmployeeType.Salary, "Eric", null, "Singer"));
            employees.Add(GetNewEmployee((int)EmployeeType.Salary, "Miti", null, "Patel"));
            employees.Add(GetNewEmployee((int)EmployeeType.Salary, "Christine", "W", "Rogers"));
            employees.Add(GetNewEmployee((int)EmployeeType.Salary, "Eddie", null, "Royal"));
            employees.Add(GetNewEmployee((int)EmployeeType.Salary, "Storm", null, "Murphy"));
            employees.Add(GetNewEmployee((int)EmployeeType.Salary, "Emily", "P", "Schmitt"));
            employees.Add(GetNewEmployee((int)EmployeeType.Salary, "Mike", null, "Young"));
            employees.Add(GetNewEmployee((int)EmployeeType.Salary, "Lawrence", "T", "Saddler"));
            employees.Add(GetNewEmployee((int)EmployeeType.Salary, "Steve", null, "Logan"));


            employees.Add(GetNewEmployee((int)EmployeeType.Manager, "Buford", "T", "Justice"));
            employees.Add(GetNewEmployee((int)EmployeeType.Manager, "James", "M", "Joseph"));
            employees.Add(GetNewEmployee((int)EmployeeType.Manager, "Paul", "D", "Brown"));
            employees.Add(GetNewEmployee((int)EmployeeType.Manager, "Luke", null, "Longley"));
            employees.Add(GetNewEmployee((int)EmployeeType.Manager, "Clement", "C", "Moore"));
            employees.Add(GetNewEmployee((int)EmployeeType.Manager, "Shara", null, "Salon"));
            employees.Add(GetNewEmployee((int)EmployeeType.Manager, "Kelly", null, "Shimzer"));
            employees.Add(GetNewEmployee((int)EmployeeType.Manager, "Janice", "L", "Gilley"));
            employees.Add(GetNewEmployee((int)EmployeeType.Manager, "Mildred", "P", "Shanks"));
            employees.Add(GetNewEmployee((int)EmployeeType.Manager, "Lizzie", "B", "Borden"));


            return employees;
        }

        public IEmployee GetNewEmployee(int empType, string first, string? middle, string last)
        {
            
            

            IEmployee newEmployee = empType switch
            {
                (int)EmployeeType.Hourly => new HourlyEmployee(_settings) { First = first, Last = last, Middle = middle },
                (int)EmployeeType.Salary => new SalaryEmployee(_settings) { First = first, Last = last, Middle = middle },
                (int)EmployeeType.Manager => new ManagerEmployee(_settings) { First = first, Last = last, Middle = middle },
                _ => new HourlyEmployee(_settings) { First = first, Last = last, Middle = middle }
            };

            return newEmployee;
        }
    }
}

using EmployeeManager.Business.Interfaces;
using EmployeeManager.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Business.Models
{
    public class WorkForce : IWorkForce
    {
        private readonly ISettings _settings;
        public List<IEmployee> Employees { get; set; }

        public IEnumerable<IEmployee> HourlyEmployees => Employees.Where(x => x.EmployeeType == EmployeeType.Hourly);
        public IEnumerable<IEmployee> SalaryEmployees => Employees.Where(x => x.EmployeeType == EmployeeType.Salary);
        public IEnumerable<IEmployee> ManagerEmployees => Employees.Where(x => x.EmployeeType == EmployeeType.Manager);

        public WorkForce(ISettings pSettings, IEmployeeServices employeeServices)
        {
            _settings = pSettings;
            Employees = employeeServices.GetWorkForceEmployees();
        }

        public void AddNewEmployee(int empType, string first, string? middle, string last)
        {
            IEmployee newEmployee = empType switch
            {
                (int)EmployeeType.Hourly => new HourlyEmployee(_settings) { First = first, Last = last, Middle = middle },
                (int)EmployeeType.Salary => new SalaryEmployee(_settings) { First = first, Last = last, Middle = middle },
                (int)EmployeeType.Manager => new ManagerEmployee(_settings) { First = first, Last = last, Middle = middle },
                _ => new HourlyEmployee(_settings) { First = first, Last = last, Middle = middle }
            };

            Employees.Add(newEmployee);
        }
    }
}

using EmployeeManager.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Business.Interfaces
{
    public interface IWorkForce
    {
        List<IEmployee> Employees { get; set; }

        public IEnumerable<IEmployee> HourlyEmployees { get; }
        public IEnumerable<IEmployee> SalaryEmployees { get; }
        public IEnumerable<IEmployee> ManagerEmployees { get; }

        void AddNewEmployee(int empType, string first, string? middle, string last);
    }
}

using EmployeeManager.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Business.Models
{
    public class Settings : ISettings
    {
        public int WorkDays { get; set; }
        public int HourlyVacationDays { get; set; }
        public int SalaryVacationDays { get; set; }
        public int ManagerVacationDays { get; set; }
    }
}

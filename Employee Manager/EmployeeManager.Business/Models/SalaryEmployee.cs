using EmployeeManager.Business.Interfaces;
using EmployeeManager.Business.Models;
using EmployeeManager.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Business.Models
{
    public class SalaryEmployee : EmployeeBase, IEmployee
    {
        public SalaryEmployee(ISettings pSettings, int pDaysWorked = 0, double? pVacationDaysTaken = null)
           : base()
        {
            settings = pSettings;
            EmployeeType = EmployeeType.Salary;
            daysOffPerYear = settings?.SalaryVacationDays ?? 0;
            vacationDaysTaken = pVacationDaysTaken ?? ((double)Math.Floor(daysOffPerYear * (DateTime.Now.DayOfYear / 365F)));
            daysWorked = (int)Math.Round((double)Math.Floor(DateTime.Today.DayOfYear * (260F / 365F)) - vacationDaysTaken);
        }
    }
}

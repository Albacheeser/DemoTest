using EmployeeManager.Business.Interfaces;
using EmployeeManager.Business.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Business.Models
{
    public class HourlyEmployee : EmployeeBase
    {
        public HourlyEmployee(ISettings pSettings, int pDaysWorked = 0, double pVacationDaysTaken = 0)
           : base()
        {
            settings = pSettings;
            EmployeeType = EmployeeType.Hourly;
            daysOffPerYear = settings?.HourlyVacationDays ?? 0;
            daysWorked = pDaysWorked;
            vacationDaysTaken = pVacationDaysTaken;
        }
    }
}

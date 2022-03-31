using EmployeeManager.Business.Enums;
using EmployeeManager.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Business.Models
{
    public class HourlyEmployee : EmployeeBase, IEmployee
    {
        public HourlyEmployee(ISettings pSettings, int pDaysWorked = 0, double? pVacationDaysTaken = null)
            :base()
        {
            settings = pSettings;
            EmployeeType = EmployeeType.Hourly;
            daysOffPerYear = settings?.HourlyVacationDays ?? 0;
            vacationDaysTaken = pVacationDaysTaken ?? ((double)Math.Floor(daysOffPerYear * (DateTime.Now.DayOfYear / 365F)));
            daysWorked = (int)Math.Round((double)Math.Floor(DateTime.Today.DayOfYear * (260F / 365F)) - vacationDaysTaken);
        }
    }
}

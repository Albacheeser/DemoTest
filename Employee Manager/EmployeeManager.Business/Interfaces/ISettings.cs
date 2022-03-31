using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Business.Interfaces
{
    public interface ISettings
    {
        int WorkDays { get; set; }
        int HourlyVacationDays { get; set; }
        int SalaryVacationDays { get; set; }
        int ManagerVacationDays { get; set; }
    }
}

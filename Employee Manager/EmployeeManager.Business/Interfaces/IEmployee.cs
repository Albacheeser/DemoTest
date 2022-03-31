using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManager.Business.Enums;

namespace EmployeeManager.Business.Interfaces
{
    public interface IEmployee
    {
        Guid Id { get; }
        string? First { get; set; }
        string? Middle { get; set; }
        string? Last { get; set; }
        EmployeeType EmployeeType { get; protected set; }
        double DaysOffPerYear {  get; }
        int DaysWorked { get; }
        double VacationDaysTaken { get; }
        void Work(int pDaysWorked);
        void TakeVacation(double pDaysTakenOff);
    }
}

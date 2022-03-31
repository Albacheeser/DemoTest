using EmployeeManager.Business.Enums;
using EmployeeManager.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Business.Models
{
    public abstract class EmployeeBase : IEmployee
    {
        protected double vacationDaysTaken;
        protected int daysWorked;
        protected double accruedVacationDays;
        protected double daysOffPerYear;
        protected ISettings? settings;

        public Guid Id { get; }
        public EmployeeType EmployeeType { get; set; }

        public double DaysOffPerYear { get => daysOffPerYear; } 
        public int DaysWorked { get => daysWorked; }
        public double VacationDaysTaken { get => vacationDaysTaken; }
        public string? First { get; set; }
        public string? Middle { get; set; }
        public string? Last { get; set; }

        public EmployeeBase()
        {
            Id = Guid.NewGuid();
        }

        public virtual void TakeVacation(double pDaysTakenOff)
        {
            vacationDaysTaken += pDaysTakenOff;
        }

        public virtual void Work(int pDaysWorked)
        {
            daysWorked += pDaysWorked;
        }
    }
}

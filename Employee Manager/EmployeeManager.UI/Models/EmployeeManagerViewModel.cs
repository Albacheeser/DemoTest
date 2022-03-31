using EmployeeManager.Business.Interfaces;

namespace EmployeeManager.UI.Models
{
    public class EmployeeManagerViewModel
    {
        public IWorkForce? WorkForce { get; set; }
        public bool UpdateSuccess { get; set;}
        public string? UpdateMessage { get; set; }
    }
}

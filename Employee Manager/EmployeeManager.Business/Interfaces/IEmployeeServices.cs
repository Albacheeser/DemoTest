using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Business.Interfaces
{
    public interface IEmployeeServices
    {
        List<IEmployee> GetWorkForceEmployees();
    }
}


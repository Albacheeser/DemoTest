using Employee_Manager.Models;
using EmployeeManager.Business.Interfaces;
using EmployeeManager.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Employee_Manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISettings _settings;
        private readonly IEmployeeServices _employeeServices;
        private readonly IWorkForce _workForce;

        public HomeController(ILogger<HomeController> logger, ISettings settings, IEmployeeServices employeeServices, IWorkForce workForce)
        {
            _logger = logger;
            _settings = settings;
            _employeeServices = employeeServices;
            _workForce = workForce;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new EmployeeManagerViewModel()
            {
                WorkForce = _workForce,
                UpdateSuccess = true,
                UpdateMessage = ""
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(Guid employeeId, bool addDayWorked, bool addDayOff)
        {
            var model = UpdateEmployeeModel(employeeId, addDayWorked, addDayOff);
            return View(model);
        }


        [HttpGet]
        public IActionResult HourlyStaff()
        {
            var model = new EmployeeManagerViewModel()
            {
                WorkForce = _workForce,
                UpdateSuccess = true,
                UpdateMessage = ""
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult HourlyStaff(Guid employeeId, bool addDayWorked, bool addDayOff)
        {
            var model = UpdateEmployeeModel(employeeId, addDayWorked, addDayOff);
            return View(model);
        }

        [HttpGet]
        public IActionResult SalariedStaff()
        {
            var model = new EmployeeManagerViewModel()
            {
                WorkForce = _workForce
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult SalariedStaff(Guid employeeId, bool addDayWorked, bool addDayOff)
        {
            var model = UpdateEmployeeModel(employeeId, addDayWorked, addDayOff);
            return View(model);
        }

        [HttpGet]
        public IActionResult ManagersStaff()
        {
            var model = new EmployeeManagerViewModel()
            {
                WorkForce = _workForce,
                UpdateSuccess = true,
                UpdateMessage = ""
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult ManagersStaff(Guid employeeId, bool addDayWorked, bool addDayOff)
        {
            var model = UpdateEmployeeModel(employeeId, addDayWorked, addDayOff);
            return View(model);
        }


        private EmployeeManagerViewModel UpdateEmployeeModel(Guid employeeId, bool addDayWorked, bool addDayOff)
        {
            var model = new EmployeeManagerViewModel()
            {
                WorkForce = _workForce,
                UpdateSuccess = true,
                UpdateMessage = ""
            };

            var employee = model.WorkForce.Employees.FirstOrDefault(x => x.Id == employeeId);
            if(employee == null)
                throw new KeyNotFoundException("Error: Could not locate the employee!");

            if (addDayOff)
            {
                if (employee.VacationDaysTaken < employee.DaysOffPerYear)
                {
                    employee.TakeVacation(1);
                }
                else
                {
                    model.UpdateSuccess = false;
                    model.UpdateMessage = "Warning: No more days left to take off!";
                }

                return model;
            }

            if (addDayWorked)
            {
                if (employee.DaysWorked < 260)
                {
                    employee.Work(1);
                }
                else
                {
                    model.UpdateSuccess = false;
                    model.UpdateMessage = "Warning: No more work days left for the year!";
                }
            }

            return model;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
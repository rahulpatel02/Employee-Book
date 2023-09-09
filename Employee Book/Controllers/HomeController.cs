using Employee_Book.Models;
using Employee_Book.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Employee_Book.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmployeeService _employeeService;  

        public HomeController(ILogger<HomeController> logger, EmployeeService employeeService )
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var list = _employeeService.GetEmployee();
            return View(list);
        }
          public IActionResult CreateEmployee()
        {
            return View();
        }
        public IActionResult AddEmployee(Employee employee)
        {
            int id=  _employeeService.AddEmp(employee );
            return RedirectToAction("Index");
        }

        public IActionResult UpdateForm(int Id)
        {
              var empData= _employeeService.GetEmployeeById(Id);
            return View(empData);
        }
        [HttpPost]
        public IActionResult UpdateEmp(Employee employee)
        {
              _employeeService.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteEmployee(int Id)
        {
            if (Id > 0)
            {
                int ans = _employeeService.DeleteEmp(Id);
            }

			return RedirectToAction("Index");
		}
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
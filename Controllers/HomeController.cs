using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeerepository _employeeRepository;

        public HomeController(IEmployeerepository employeerepository)
        {
            _employeeRepository = employeerepository;
        }
        public string Index() {
            return _employeeRepository.GetEmployee(1).Name;
        }
    }
}

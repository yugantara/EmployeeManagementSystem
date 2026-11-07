namespace EmployeeManagement.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employees;

        public EmployeeRepository()
        {
            _employees = new List<Employee>()
            {
                new Employee() {Id = 1, Name = "Yugantara", Department = Dept.IT, Email = "ym@hitachids.com"},
                new Employee() {Id = 2, Name = "Neha", Department = Dept.Compliance, Email = "nc@hitachids.com"},
                new Employee() {Id = 3, Name = "Ayushi", Department = Dept.AI, Email = "at@hitachids.com"},
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employees;
        }

        public Employee GetEmployee(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public Employee Delete(int id)
        {
            Employee employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
            return employee;
        }

        public Employee Update(Employee employee)
        {
            Employee employeeToUpdate = _employees.FirstOrDefault(e => e.Id == employee.Id);
            if (employeeToUpdate != null)
            {
                employeeToUpdate.Name = employee.Name;
                employeeToUpdate.Email = employee.Email;
                employeeToUpdate.Department = employee.Department;
            }
            return employeeToUpdate;
        }
    }
}

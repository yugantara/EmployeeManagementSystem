namespace EmployeeManagement.Models
{
    public class EmployeeRepository : IEmployeerepository
    {
        private List<Employee> _employees;

        public EmployeeRepository()
        {
            _employees = new List<Employee>()
            {
                new Employee() {Id = 1, Name = "Yugantara", Department = "Cloud and Data", Email = "ym@hitachids.com"},
                new Employee() {Id = 2, Name = "Neha", Department = "Compliance", Email = "nc@hitachids.com"},
                new Employee() {Id = 3, Name = "Ayushi", Department = "AI", Email = "at@hitachids.com"},
            };
        }
        public Employee GetEmployee(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }
    }
}

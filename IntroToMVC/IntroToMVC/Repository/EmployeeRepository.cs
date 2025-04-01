using IntroToMVC.Models;

namespace IntroToMVC.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        static List<Employee> _employees = new List<Employee>();

        static EmployeeRepository()
        {
            Employee objEmployee = new Employee();
            objEmployee.Id = 1;
            objEmployee.Name = "Ram";
            objEmployee.Salary = 50000;
            objEmployee.City = "New Delhi";
            _employees.Add(objEmployee);

            _employees.Add(new Employee() { Id = 2, Name = "Satyam", Salary = 10000, City = "Bihar" });
            _employees.Add(new Employee() { Id = 3, Name = "Shubham", Salary = 100000, City = "Mumbai" });
        }

        public void AddEmployee(Employee emp)
        {
            _employees.Add(emp);
        }

        public void DeleteEmployee(int id)
        {
            //using Linq

            var employee = _employees.First(value => value.Id == id);

            _employees.Remove(employee);
        }

        public Employee GetEmployeeById(int id)
        {
            //return _employees.ElementAt(id);  it treats as zero based indexing. so no use here

            //Linq = Language Integrated Query

            var employee = _employees.First(value=>value.Id==id);   //valid or we can use for loop or foreach
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            return _employees;
        }

        public void UpdateEmployee(Employee emp)
        {
            var employee = _employees.First(value => value.Id == emp.Id);  //it fetches employee which have same id.

            //Now we update it
            employee.Name = emp.Name;
            employee.Salary = emp.Salary;
            employee.City = emp.City;
        }
    }
}

using IntroToMVC.Models;

namespace IntroToMVC.Repository
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee emp);

        void DeleteEmployee(int id);

        Employee GetEmployeeById(int id);

        List<Employee> GetEmployees();
    
        void UpdateEmployee(Employee emp);
    }
}

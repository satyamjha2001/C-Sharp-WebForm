using MVC_CRUD_ADO_NET.Models;

namespace MVC_CRUD_ADO_NET.Repository
{
    public class EmpRepo : IEmpRepo
    {
        static List<EmpModel> _employees = new List<EmpModel>();

        static EmpRepo()
        {
            EmpModel objEmployee = new EmpModel();
            objEmployee.Id = 1;
            objEmployee.Name = "Ram";
            objEmployee.Salary = 50000;
            objEmployee.City = "New Delhi";
            _employees.Add(objEmployee);

            _employees.Add(new EmpModel() { Id = 2, Name = "Satyam", Salary = 10000, City = "Bihar" });
            _employees.Add(new EmpModel() { Id = 3, Name = "Shubham", Salary = 100000, City = "Mumbai" });
        }
        public void AddEmployee(EmpModel emp)
        {
            _employees.Add(emp);
        }

        public void DeleteEmployee(int id)
        {
            var employee = _employees.First(value => value.Id == id);
            _employees.Remove(employee);
        }

        public EmpModel GetEmployeeById(int id)
        {
            var employee = _employees.First(value => value.Id == id);   //valid or we can use for loop or foreach
            return employee;
        }

        public List<EmpModel> GetEmployees()
        {
            return _employees;
        }

        public void UpdateEmployee(EmpModel emp)
        {
            var employee = _employees.First(value => value.Id == emp.Id);  //it fetches employee which have same id.

            //Now we update it
            employee.Name = emp.Name;
            employee.Salary = emp.Salary;
            employee.City = emp.City;
        }
    }
}

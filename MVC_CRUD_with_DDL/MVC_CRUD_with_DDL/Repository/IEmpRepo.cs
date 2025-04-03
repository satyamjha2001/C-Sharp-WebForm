using MVC_CRUD_with_DDL.Models;

namespace MVC_CRUD_with_DDL.Repository
{
    public interface IEmpRepo
    {
        void AddEmployee(EmpModel emp);

        void DeleteEmployee(int id);

        EmpModel GetEmployeeById(int id);

        List<EmpModel> GetEmployees();

        void UpdateEmployee(EmpModel emp);
    }
}

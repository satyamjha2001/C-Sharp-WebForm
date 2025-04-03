using MVC_CRUD_ADO_NET.Models;

namespace MVC_CRUD_ADO_NET.Repository
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

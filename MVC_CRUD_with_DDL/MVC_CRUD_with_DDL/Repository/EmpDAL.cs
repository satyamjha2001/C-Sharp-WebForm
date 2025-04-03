using MVC_CRUD_with_DDL.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MVC_CRUD_with_DDL.Repository
{
    public class EmpDAL : IEmpRepo
    {
        string cs = ConnectionString.dbcs;
        public void AddEmployee(EmpModel emp)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Usp_AddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", emp.Name);
                cmd.Parameters.AddWithValue("@salary",emp.Salary);
                cmd.Parameters.AddWithValue("@City", emp.City);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteEmployee(int id)
        {
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Usp_DeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public EmpModel GetEmployeeById(int id)
        {
            EmpModel emp = new EmpModel();
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Usp_GetEmployeeById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    emp.Id = Convert.ToInt32(reader["id"]);
                    emp.Name = reader["name"].ToString() ?? "";  //agar null aaegaa to empty set hoga
                    emp.Salary = Convert.ToInt32(reader["salary"]);
                    emp.City = reader["city"].ToString() ?? "";
                }
            }
            return emp;
        }

        public List<EmpModel> GetEmployees()
        {
            List<EmpModel> empList = new List<EmpModel>();

            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Usp_GetEmployees",con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EmpModel emp = new EmpModel();
                    emp.Id = Convert.ToInt32(reader["id"]);
                    emp.Name = reader["name"].ToString() ?? "";  //agar null aaegaa to empty set hoga
                    emp.Salary = Convert.ToInt32(reader["salary"]);
                    emp.City = reader["city"].ToString() ?? "";
                    empList.Add(emp);
                }
            }

            return empList;
        }

        public void UpdateEmployee(EmpModel emp)
        {
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Usp_UpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", emp.Id);
                cmd.Parameters.AddWithValue("@name", emp.Name);
                cmd.Parameters.AddWithValue("@salary", emp.Salary);
                cmd.Parameters.AddWithValue("@City", emp.City);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

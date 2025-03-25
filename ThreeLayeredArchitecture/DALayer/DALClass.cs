using System;
using System.Data;
using System.Data.SqlClient;


namespace DALayer
{
    public class DALClass
    {
        public void insertDetail(string name, string email, decimal fees, int cId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ThreeTierDB;Integrated Security=True;"))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.Usp_InsertStudent", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@Fee", fees);
                            cmd.Parameters.AddWithValue("@CourseId", cId);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in insertDetail: " + ex.Message);
            }
        }

        public object getDetail()
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ThreeTierDB;Integrated Security=True;"))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.Usp_GetAllStudent", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getDetail: " + ex.Message);
            }
        }

        public void EditDetail(int sid, string name, string email, decimal fees, int cId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ThreeTierDB;Integrated Security=True;"))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.Usp_EditStudent", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SId", sid);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Fee", fees);
                        cmd.Parameters.AddWithValue("@CourseId", cId);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in EditDetail: " + ex.Message);
            }
        }

        public void DeleteDetail(int sid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ThreeTierDB;Integrated Security=True;"))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.Usp_DeleteStudent", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SId", sid);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in DeleteDetail: " + ex.Message);
            }
        }


    }
}


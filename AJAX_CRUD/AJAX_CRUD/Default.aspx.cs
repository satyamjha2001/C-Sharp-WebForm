using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace AJAX_CRUD
{
    public partial class WebForm1 : System.Web.UI.Page
    {


        private void reset()
        {
            txtName.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
            DropDownGender.SelectedIndex = 0;
            txtDOB.Text = "";
            chkCricket.Checked = false;
            chkFootball.Checked = false;
            chkMovies.Checked = false;
            chkReading.Checked = false;
        }
        private string GetHobbies()
        {
            string hobbies = "";
            if (chkCricket.Checked) hobbies += "Cricket, ";
            if (chkFootball.Checked) hobbies += "Football, ";
            if (chkReading.Checked) hobbies += "Reading, ";
            if (chkMovies.Checked) hobbies += "Movies, ";

            return hobbies.TrimEnd(',', ' ');
        }

        protected void ValidateHobbies(object source, ServerValidateEventArgs args)
        {
            args.IsValid = chkCricket.Checked || chkFootball.Checked || chkReading.Checked || chkMovies.Checked;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }



        protected bool Validation()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtMobile.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtDOB.Text) ||
                DropDownGender.SelectedIndex == 0)
            {
                return false;
            }

            if (!Regex.IsMatch(txtMobile.Text, @"^[6-9]\d{9}$"))
            {
                return false;
            }

            if (!Regex.IsMatch(txtEmail.Text, @"^[\w\.-]+@[\w\.-]+\.\w+$"))
            {
                return false;
            }

            // Ensure at least one hobby is selected
            if (!(chkCricket.Checked || chkFootball.Checked || chkReading.Checked || chkMovies.Checked))
            {
                return false;
            }

            return true;
        }

        protected void btnEdit_Click()
        {
            Response.Write("<script></script>");
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //if (!Validation())
            //{
            //    return;
            //}
            if (IsValid)
            {
                //Validation();
                string con = "Data Source=.;Initial Catalog=User;Integrated Security=True;";
                using (SqlConnection db = new SqlConnection(con))
                {
                    db.Open();

                    string hobbies = GetHobbies();
                    using (SqlCommand cmd = new SqlCommand("dbo.Usp_Insert", db))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Gender", DropDownGender.SelectedValue);
                        cmd.Parameters.AddWithValue("@Hobbies", hobbies);
                        cmd.Parameters.AddWithValue("@DOB", txtDOB.Text);

                        int m = cmd.ExecuteNonQuery();
                        if (m > 0)
                        {
                            Response.Write("<script>alert('data inserted successfully!')</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('data insertion failed!!')</script>");
                        }
                    }
                }
                reset();
            }
        }

        [WebMethod]
        public static string GetUserData()
        {
            string con = "Data Source=.;Initial Catalog=User;Integrated Security=True;";
            DataTable dt = new DataTable();
            using (SqlConnection db = new SqlConnection(con))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Users", db))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            List<Dictionary<string, object>> userList = new List<Dictionary<string, object>>();

            foreach (DataRow row in dt.Rows)
            {
                Dictionary<string, object> user = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    user[col.ColumnName] = row[col];  // Store column values
                }
                userList.Add(user);
            }

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(userList);
        }
    }
}
using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormWithSQL
{
    public partial class Default : System.Web.UI.Page
    {

        protected bool Flag
        {
            get { return ViewState["Flag"] != null ? (bool)ViewState["Flag"] : false; }
            set { ViewState["Flag"] = value; }
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
        private void BindGrid()
        {
            string con = "Data Source=.;Initial Catalog=User;Integrated Security=True;";
            using (SqlConnection db = new SqlConnection(con))
            {
                db.Open();
                string query = "SELECT Id, Name, Mobile, Email, Gender, Hobbies, CONVERT(varchar, DOB, 23) AS DOB, Added_Date FROM Users";
                using (SqlCommand cmd = new SqlCommand(query, db))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        FormGridView.DataSource = dt;
                        FormGridView.DataBind();
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ValidateHobbies(object source, ServerValidateEventArgs args)
        {
            args.IsValid = chkCricket.Checked || chkFootball.Checked || chkReading.Checked || chkMovies.Checked;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string con = "Data Source=.;Initial Catalog=User;Integrated Security=True;";
            using (SqlConnection db = new SqlConnection(con))
            {
                db.Open();

                string hobbies = GetHobbies();
                string insert;
                if (ViewState["EditID"] == null)
                {
                    insert = "INSERT INTO Users (Name, Mobile, Email, Gender, Hobbies, DOB, Added_Date) VALUES (@Name, @Mobile, @Email, @Gender, @Hobbies, @DOB, GETDATE())";
                }

                else
                {
                    insert = "UPDATE Users SET Name=@Name, Mobile=@Mobile, Email=@Email, Gender=@Gender, Hobbies=@Hobbies, DOB=@DOB WHERE Id=@Id";
                }

                using (SqlCommand cmd = new SqlCommand(insert, db))
                {
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Gender", DropDownGender.SelectedValue);
                    cmd.Parameters.AddWithValue("@Hobbies", hobbies);
                    cmd.Parameters.AddWithValue("@DOB", txtDOB.Text);

                    if (ViewState["EditID"] != null)
                    {
                        cmd.Parameters.AddWithValue("@Id", ViewState["EditID"]);
                    }

                    int m = cmd.ExecuteNonQuery();
                    if (m > 0)
                    {
                        Response.Write("<script>alert('Success!')</script>");
                            //BindGrid();
                    }
                    else
                    {
                        Response.Write("<script>alert('Failed!!')</script>");
                    }
                }
            }
            if(FormGridView.Visible)
            {
                BindGrid();
            }
            ViewState["EditID"] = null;
            btnSubmit.Text = "Submit";
            reset();
        }

        protected void btnShowData_Click(object sender, EventArgs e)
        {
            if (!Flag)
            {
                BindGrid();
                FormGridView.Visible=true;
                btnShowData.Text = "Hide Data";
                Flag = true;
            }
            else
            {
                //FormGridView.DataSource = null;
                //FormGridView.DataBind();
                FormGridView.Visible = false;
                btnShowData.Text = "Show Data";
                Flag = false;
            }
        }

        protected void OnClick_btnEdit(object sender, EventArgs e)
        {
            btnSubmit.Text = "Update";
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int id = Convert.ToInt32(FormGridView.DataKeys[row.RowIndex].Value);

            string con = "Data Source=.;Initial Catalog=User;Integrated Security=True;";
            using (SqlConnection db = new SqlConnection(con))
            {
                db.Open();
                string query = "SELECT * FROM Users WHERE Id=@Id";
                using (SqlCommand cmd = new SqlCommand(query, db))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtName.Text = reader["Name"].ToString();
                        txtMobile.Text = reader["Mobile"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        DropDownGender.SelectedValue = reader["Gender"].ToString();
                        txtDOB.Text = Convert.ToDateTime(reader["DOB"]).ToString("yyyy-MM-dd");

                        chkCricket.Checked = reader["Hobbies"].ToString().Contains("Cricket");
                        chkFootball.Checked = reader["Hobbies"].ToString().Contains("Football");
                        chkReading.Checked = reader["Hobbies"].ToString().Contains("Reading");
                        chkMovies.Checked = reader["Hobbies"].ToString().Contains("Movies");

                        ViewState["EditID"] = id;
                    }
                }
            }
        }

        protected void OnClick_btnDelete(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int id = Convert.ToInt32(FormGridView.DataKeys[row.RowIndex].Value);

            string con = "Data Source=.;Initial Catalog=User;Integrated Security=True;";
            using (SqlConnection db = new SqlConnection(con))
            {
                db.Open();
                string query = "DELETE FROM Users WHERE Id=@Id";
                using (SqlCommand cmd = new SqlCommand(query, db))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        Response.Write("<script>alert('Record Deleted Successfully!')</script>");
                        BindGrid();
                    }
                    else
                    {
                        Response.Write("<script>alert('Record Deletion Failed!')</script>");
                    }
                }
            }
        }
    }
}

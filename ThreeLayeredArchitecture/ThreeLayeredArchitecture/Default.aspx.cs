using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using BAL;

namespace ThreeLayeredArchitecture
{
    public partial class Default : System.Web.UI.Page
    {
        BALClass balObj = new BALClass();
        static int editSId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ThreeTierDB;Integrated Security=True");
            if (!IsPostBack)
            {
                BindCourseDDL();
                BindGridView();
            }
        }

        public void BindCourseDDL()
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ThreeTierDB;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.Usp_GetAllCourse", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            ddlCourse.DataSource = dr;
                            ddlCourse.DataTextField = "CourseName";
                            ddlCourse.DataValueField = "Cid";
                            ddlCourse.DataBind();
                        }
                    }
                }
                ddlCourse.Items.Insert(0, new ListItem("Choose", "0"));
            }
            catch (Exception ex)
            {
                lblMsg.Text = "<b style='color:red'>" + ex.Message + "</b><br/>";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (editSId == 0)
                {
                    balObj.InsertStudent(txtName.Text, txtEmail.Text, Convert.ToDecimal(txtFees.Text), Convert.ToInt32(ddlCourse.SelectedValue));
                    lblMsg.Text = "<b style='color:green'>Student added successfully!</b>";
                }
                else
                {
                    balObj.UpdateStudent(editSId, txtName.Text, txtEmail.Text, Convert.ToDecimal(txtFees.Text), Convert.ToInt32(ddlCourse.SelectedValue));
                    lblMsg.Text = "<b style='color:green'>Student updated successfully!</b>";
                    editSId = 0;
                }
                
                BindGridView();
                reset();
            }
            catch (Exception ex)
            {
                lblMsg.Text = "<b style='color:red'>" + ex.Message + "</b>";
            }
        }

        void BindGridView()
        {
            try
            {
                BALClass balObj = new BALClass();
                DataTable dt = balObj.SelectStudent();

                if (dt.Rows.Count > 0)
                {
                    grdStudent.DataSource = dt;
                    grdStudent.DataBind();
                }
                else
                {
                    grdStudent.DataSource = null;
                    grdStudent.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "<b style='color:red'>Error Loading Data: " + ex.Message + "</b>";
            }
        }

        protected void OnClick_btnEdit(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            editSId = Convert.ToInt32(grdStudent.DataKeys[row.RowIndex].Value);
            txtName.Text = row.Cells[1].Text;
            txtEmail.Text = row.Cells[2].Text;
            txtFees.Text = row.Cells[3].Text;
            BindCourseDDL();

            string courseId = row.Cells[4].Text;
            ListItem selectedCourse = ddlCourse.Items.FindByText(courseId);

            if (selectedCourse != null)
            {
                ddlCourse.SelectedValue = selectedCourse.Value;
            }
            else
            {
                lblMsg.Text = "<b style='color:blue'>Editing Student ID: " + editSId + "</b>";
            }
        }

        protected void OnClick_btnDelete(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                int sid = Convert.ToInt32(grdStudent.DataKeys[row.RowIndex].Value);

                balObj.RemoveStudent(sid);
                lblMsg.Text = "<b style='color:red'>Student deleted successfully!</b>";
                BindGridView();
            }
            catch (Exception ex)
            {
                lblMsg.Text = "<b style='color:red'>" + ex.Message + "</b>";
            }
        }
        void reset()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtFees.Text = "";
            ddlCourse.SelectedIndex = 0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationForm
{
    public partial class GridViewFinal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Name");
                dt.Columns.Add("Email");
                dt.Columns.Add("Address");
                dt.Columns.Add("Gender");
                dt.Columns.Add("DOB");
                dt.Columns.Add("Course");
                dt.Columns.Add("PassWord");
                dt.Columns.Add("Shift");
                dt.Columns.Add("Options");


                // Store in session
                Session["RegistrationData"] = dt;

                // Bind to GridView
                RegistrationGridView.DataSource = dt;
                RegistrationGridView.DataBind();
            }

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //First Retrieve DataTable from Session
            DataTable dt = (DataTable)Session["RegistrationData"];

            // Determine selected gender
            string gender = M.Checked ? "Male" : (F.Checked ? "Female" : "Not Selected");

            //Determine selected shift
            string shift = "";
            if (Morning.Checked) shift += " Morning";
            if (Noon.Checked) shift += " Noon";
            if (Evening.Checked) shift += " Evening";
            shift = string.IsNullOrEmpty(shift) ? "Not Selected" : shift.Trim();

            // Add new row to DataTable
            dt.Rows.Add(
                txtName.Text,
                txtEmail.Text,
                txtAddress.Text,
                gender,
                txtDOB.Text,
                CourseDropDown.SelectedValue,
                txtPassword.Text,
                shift
            );

            // Store updated DataTable in session
            Session["RegistrationData"] = dt;

            // Bind updated data to GridView
            RegistrationGridView.DataSource = dt;
            RegistrationGridView.DataBind();
            reset();
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            reset();
        }
        public void reset()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            M.Checked = false;
            F.Checked = false;
            txtDOB.Text = "";
            CourseDropDown.SelectedIndex = 0;
            txtPassword.Text = "";
            Morning.Checked = false;
            Noon.Checked = false;
            Evening.Checked = false;
        }

        // Edit Row
        protected void RegistrationGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DataTable dt = (DataTable)Session["RegistrationData"];
            RegistrationGridView.EditIndex = e.NewEditIndex;
            RegistrationGridView.DataSource = dt;
            RegistrationGridView.DataBind();
        }

        // Cancel Edit
        protected void RegistrationGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DataTable dt = (DataTable)Session["RegistrationData"];
            RegistrationGridView.EditIndex = -1;
            RegistrationGridView.DataSource = dt;
            RegistrationGridView.DataBind();
        }

        // Update Row
        protected void RegistrationGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DataTable dt = (DataTable)Session["RegistrationData"];

            int rowIndex = e.RowIndex;
            GridViewRow row = RegistrationGridView.Rows[rowIndex];

            dt.Rows[rowIndex]["Address"] = ((TextBox)row.Cells[2].Controls[0]).Text;
            dt.Rows[rowIndex]["Course"] = ((TextBox)row.Cells[5].Controls[0]).Text;
            dt.Rows[rowIndex]["PassWord"] = ((TextBox)row.Cells[6].Controls[0]).Text;
            dt.Rows[rowIndex]["Shift"] = ((TextBox)row.Cells[7].Controls[0]).Text;

            Session["RegistrationData"] = dt;
            RegistrationGridView.EditIndex = -1;
            RegistrationGridView.DataSource = dt;
            RegistrationGridView.DataBind();
        }

        // Delete Row
        protected void RegistrationGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)Session["RegistrationData"];
            dt.Rows.RemoveAt(e.RowIndex);
            Session["RegistrationData"] = dt;
            RegistrationGridView.DataSource = dt;
            RegistrationGridView.DataBind();
        }
    }
}
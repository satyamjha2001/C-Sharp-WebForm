using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationForm
{
	public partial class Gridview : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if(!IsPostBack)
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


                // Store in ViewState
                ViewState["RegistrationData"] = dt;

                // Bind to GridView
                RegistrationGridView.DataSource = dt;
                RegistrationGridView.DataBind();
            }

		}

        protected void Submit_Click(object sender, EventArgs e)
        {
            //First Retrieve DataTable from Session
            DataTable dt = (DataTable)ViewState["RegistrationData"];

            // Determine selected gender
            string gender = M.Checked ? "Male" : (F.Checked ? "Female" : "Not Selected");

            //Determine selected shift
            string shift = "";
            if (Morning.Checked) shift += " Morning";
            if (Noon.Checked) shift += " Noon";
            if (Evening.Checked) shift += " Evening";
            shift = string.IsNullOrEmpty(shift) ? "Not Selected" : shift.Trim();

            //EditRow of DataTable
            if (ViewState["EditIndex"] != null)
            {
                int index = (int)ViewState["EditIndex"];

                // Update row values
                dt.Rows[index]["Name"] = txtName.Text;
                dt.Rows[index]["Email"] = txtEmail.Text;
                dt.Rows[index]["Address"] = txtAddress.Text;
                dt.Rows[index]["Gender"] = gender;
                dt.Rows[index]["DOB"] = txtDOB.Text;
                dt.Rows[index]["Course"] = CourseDropDown.SelectedValue;
                dt.Rows[index]["PassWord"] = txtPassword.Text;
                dt.Rows[index]["Shift"] = shift;

                ViewState["EditIndex"] = null;  // Clear edit state
            }
            else
            {   // Add new row to DataTable
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
            }
            // Store updated DataTable in ViewState
            ViewState["RegistrationData"] = dt;

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

        protected void OnClick_btnEdit(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int index = row.RowIndex;  // Get row index

            ViewState["EditIndex"] = index;  // Store row index in ViewState

            DataTable dt = (DataTable)ViewState["RegistrationData"];

            // Populate form fields with row data
            txtName.Text = dt.Rows[index]["Name"].ToString();
            txtEmail.Text = dt.Rows[index]["Email"].ToString();
            txtAddress.Text = dt.Rows[index]["Address"].ToString();

            string gender = dt.Rows[index]["Gender"].ToString();
            M.Checked = gender == "Male";
            F.Checked = gender == "Female";

            txtDOB.Text = dt.Rows[index]["DOB"].ToString();
            CourseDropDown.SelectedValue = dt.Rows[index]["Course"].ToString();
            txtPassword.Text = dt.Rows[index]["PassWord"].ToString();

            string shift = dt.Rows[index]["Shift"].ToString();
            Morning.Checked = shift.Contains("Morning");
            Noon.Checked = shift.Contains("Noon");
            Evening.Checked = shift.Contains("Evening");
        }

        protected void OnClick_btnDelete(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int index = row.RowIndex;  // Get row index

            DataTable dt = (DataTable)ViewState["RegistrationData"];
            dt.Rows.RemoveAt(index);  // Remove the row

            ViewState["RegistrationData"] = dt;  // Update ViewState
            RegistrationGridView.DataSource = dt;
            RegistrationGridView.DataBind();
        }
    }
}
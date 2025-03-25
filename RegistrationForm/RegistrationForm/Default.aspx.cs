using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationForm
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            NameValue.Text = "Your name is " + NameTextBox.Text;
            EmailValue.Text = "Your email is " + EmailTextBox.Text;
            AddressValue.Text = "Your address is " + AddressTextBox.Text;
            DOBValue.Text = "Your date of birth is " + DOBTextBox.Text;
            CourseValue.Text = "You have selected " + CourseDropDown.SelectedValue.ToString();
            PasswordValue.Text = "Your password is " + PasswordTextBox.Text;

            if (M.Checked)
            {
                GenderValue.Text = "Your Gender is " + M.Text;
            }
            else if (F.Checked)
            {
                GenderValue.Text = "Your Gender is " + F.Text;
            }

            else
            {
                GenderValue.Text = "You Not Selected Gender";
            }

            if(Morning.Checked || Noon.Checked || Evening.Checked)
            {
                ShiftValue.Text = "You have selected ";
            }
            if (Morning.Checked)
            {
                ShiftValue.Text += " " + Morning.Text;
            }
            if (Noon.Checked)
            {
                ShiftValue.Text += " " + Noon.Text;
            }
            if (Evening.Checked)
            {
                ShiftValue.Text += " " + Evening.Text;
            }
            if(!Morning.Checked && !Noon.Checked && !Evening.Checked)
            {
                ShiftValue.Text = "You have not selected any shift";
            }
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            NameTextBox.Text = "";
            NameValue.Text = "";
            EmailTextBox.Text = "";
            EmailValue.Text = "";
            AddressTextBox.Text = "";
            AddressValue.Text = "";
            GenderValue.Text = "";
            M.Checked = false;
            F.Checked = false;
            DOBTextBox.Text = "";
            DOBValue.Text = "";
            CourseValue.Text = "";
            CourseDropDown.SelectedIndex = 0;
            PasswordTextBox.Text = "";
            PasswordValue.Text = "";
            ShiftValue.Text = "";
            Morning.Checked = false;
            Noon.Checked = false;
            Evening.Checked = false;
        }
    }
}
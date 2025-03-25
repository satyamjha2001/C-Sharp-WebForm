using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormJavaTPoint
{
    public partial class _08CheckBox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowCourse.Text = "None";
        }

        protected void SubmitButton(object sender, EventArgs e)
        {
            string message = "";
            if (CheckBox1.Checked)
            {
                message += CheckBox1.Text + " ";
            }
            if (CheckBox2.Checked)
            {
                message += CheckBox2.Text + " ";
            }
            if (CheckBox3.Checked)
            {
                message += CheckBox3.Text;
            }
            ShowCourse.Text = message;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace View_State
{
	public partial class WebForm1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            ViewState["user"] = UserTextBox.Text;
            ViewState["pass"] = PasswordTextBox.Text;
            UserTextBox.Text = "";
            PasswordTextBox.Text = "";
        }

        protected void RestoreButton_Click(object sender, EventArgs e)
        {
            if(ViewState["user"] != null)
            {
                UserTextBox.Text = ViewState["user"].ToString();
            }
            if (ViewState["pass"] != null)
            {
                PasswordTextBox.Text = ViewState["pass"].ToString();
            }
        }
    }
}
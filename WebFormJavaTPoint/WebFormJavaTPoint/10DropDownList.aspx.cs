using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormJavaTPoint
{
    public partial class _10DropDownList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Clicked(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 0) { 
                ResultLabel.Text = "Please select a value from the list.";
            }
            else { 
                ResultLabel.Text = "You selected: " + DropDownList1.SelectedValue;
            }
        }
    }
}
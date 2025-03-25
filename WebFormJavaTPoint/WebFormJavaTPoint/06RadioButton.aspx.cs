using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormJavaTPoint
{
	public partial class _06RadioButton : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}
        protected void SubmitButtoN_Click(object sender, EventArgs e)
        {
			genderId.Text="";
			if (M.Checked)
			{
				genderId.Text = "Your Gender is " + M.Text;
			}
			else
			{
                genderId.Text = "Your Gender is " + F.Text;
            }

        }
    }
}
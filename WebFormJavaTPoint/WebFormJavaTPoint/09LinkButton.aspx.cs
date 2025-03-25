using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormJavaTPoint
{
	public partial class _09LinkButton : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
			Label1.Text = "This PC is infected with virus. Thanks for clicking.😈";
        }
    }
}
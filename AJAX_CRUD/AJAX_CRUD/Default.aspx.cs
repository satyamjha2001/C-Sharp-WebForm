using System;
using System.Threading;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace AJAX_CRUD
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		[WebMethod]
		public static string GetData(string fname, string sname)
		{
            //Thread.Sleep(3000);
            //return "Your firstname is " + fname + " and surname is " +sname;
			string con = "Data Source =.; Initial Catalog = AjaxDB; Integrated Security = True;";
			SqlConnection db = new SqlConnection(con);
			string query = "INSERT INTO person VALUES(@fname,@sname)";
			SqlCommand cmd = new SqlCommand(query, db);
			cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@sname", sname);
			db.Open();
			int a = cmd.ExecuteNonQuery();
			db.Close();
			if (a > 0)
			{
				return "Data inserted successfully";
			}
			else
			{
                return "Data insertion failed";
            }
        }
	}
}
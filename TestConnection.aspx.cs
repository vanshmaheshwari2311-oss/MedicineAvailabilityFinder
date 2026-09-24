using System;
using System.Configuration;
using System.Data.SqlClient;

namespace MedicineAvailabilityFinder
{
    public partial class TestConnection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString =
                ConfigurationManager
                .ConnectionStrings["MedicineDBConnection"]
                .ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    lblMessage.Text =
                        "✅ Database Connected Successfully!";

                    lblMessage.ForeColor =
                        System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text =
                    "❌ Connection Failed: " + ex.Message;

                lblMessage.ForeColor =
                    System.Drawing.Color.Red;
            }
        }
    }
}

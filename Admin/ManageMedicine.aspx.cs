using System;
using System.Data;
using System.Data.SqlClient;
using MedicineAvailabilityFinder.DAL;

namespace MedicineAvailabilityFinder.Admin
{
    public partial class ManageMedicine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMedicines();
            }
        }

        protected void btnAddMedicine_Click(object sender, EventArgs e)
        {
            string medicineName = txtMedicineName.Text.Trim();
            string genericName = txtGenericName.Text.Trim();
            string category = txtCategory.Text.Trim();
            string strength = txtStrength.Text.Trim();

            if (medicineName == "")
            {
                lblMessage.Text = "Please enter medicine name.";
                lblMessage.ForeColor =
                    System.Drawing.Color.Red;

                return;
            }

            string query = @"
                INSERT INTO Medicine
                (
                    MedicineName,
                    GenericName,
                    Category,
                    Strength
                )
                VALUES
                (
                    @MedicineName,
                    @GenericName,
                    @Category,
                    @Strength
                )";

            try
            {
                using (SqlConnection con =
                    DatabaseHelper.GetConnection())
                {
                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@MedicineName",
                            medicineName);

                        cmd.Parameters.AddWithValue(
                            "@GenericName",
                            genericName);

                        cmd.Parameters.AddWithValue(
                            "@Category",
                            category);

                        cmd.Parameters.AddWithValue(
                            "@Strength",
                            strength);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }

                lblMessage.Text =
                    "✅ Medicine added successfully!";

                lblMessage.ForeColor =
                    System.Drawing.Color.Green;

                ClearFields();

                LoadMedicines();
            }
            catch (Exception ex)
            {
                lblMessage.Text =
                    "❌ Error: " + ex.Message;

                lblMessage.ForeColor =
                    System.Drawing.Color.Red;
            }
        }

        private void LoadMedicines()
        {
            string query = @"
                SELECT
                    MedicineId,
                    MedicineName,
                    GenericName,
                    Category,
                    Strength
                FROM Medicine
                ORDER BY MedicineId DESC";

            try
            {
                using (SqlConnection con =
                    DatabaseHelper.GetConnection())
                {
                    using (SqlCommand cmd =
                        new SqlCommand(query, con))
                    {
                        using (SqlDataAdapter da =
                            new SqlDataAdapter(cmd))
                        {
                            DataTable dt =
                                new DataTable();

                            da.Fill(dt);

                            gvMedicines.DataSource = dt;

                            gvMedicines.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text =
                    "❌ Error loading medicines: "
                    + ex.Message;
            }
        }

        private void ClearFields()
        {
            txtMedicineName.Text = "";
            txtGenericName.Text = "";
            txtCategory.Text = "";
            txtStrength.Text = "";
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using MedicineAvailabilityFinder.DAL;

namespace MedicineAvailabilityFinder.Admin
{
    public partial class ManagePharmacy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPharmacies();
            }
        }

        protected void btnAddPharmacy_Click(object sender, EventArgs e)
        {
            string pharmacyName = txtPharmacyName.Text.Trim();
            string area = txtArea.Text.Trim();
            string address = txtAddress.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (pharmacyName == "" ||
                area == "" ||
                address == "" ||
                phone == "")
            {
                lblMessage.Text =
                    "Please fill all fields.";

                lblMessage.ForeColor =
                    System.Drawing.Color.Red;

                return;
            }

            string query = @"
                INSERT INTO Pharmacy
                (
                    PharmacyName,
                    Area,
                    Address,
                    Phone
                )
                VALUES
                (
                    @PharmacyName,
                    @Area,
                    @Address,
                    @Phone
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
                            "@PharmacyName",
                            pharmacyName);

                        cmd.Parameters.AddWithValue(
                            "@Area",
                            area);

                        cmd.Parameters.AddWithValue(
                            "@Address",
                            address);

                        cmd.Parameters.AddWithValue(
                            "@Phone",
                            phone);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }

                lblMessage.Text =
                    "✅ Pharmacy added successfully!";

                lblMessage.ForeColor =
                    System.Drawing.Color.Green;

                ClearFields();

                LoadPharmacies();
            }
            catch (Exception ex)
            {
                lblMessage.Text =
                    "❌ Error: " + ex.Message;

                lblMessage.ForeColor =
                    System.Drawing.Color.Red;
            }
        }


        private void LoadPharmacies()
        {
            string query = @"
                SELECT
                    PharmacyId,
                    PharmacyName,
                    Area,
                    Address,
                    Phone
                FROM Pharmacy
                ORDER BY PharmacyId DESC";

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

                            gvPharmacies.DataSource = dt;

                            gvPharmacies.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text =
                    "❌ Error loading pharmacies: "
                    + ex.Message;
            }
        }


        private void ClearFields()
        {
            txtPharmacyName.Text = "";
            txtArea.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
        }
    }
}

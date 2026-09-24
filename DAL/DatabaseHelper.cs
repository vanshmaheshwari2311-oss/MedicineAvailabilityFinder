using System.Configuration;
using System.Data.SqlClient;

namespace MedicineAvailabilityFinder.DAL
{
    public class DatabaseHelper
    {
        private static readonly string connectionString =
            ConfigurationManager
            .ConnectionStrings["MedicineDBConnection"]
            .ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}

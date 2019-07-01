using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace alphaEventViewer
{
    public static class ConnectionFactory
    {
        /// <summary>
        ///     Creates and opens a new connection
        /// </summary>
        /// <returns></returns>
        public static async Task<IDbConnection> CreateAsync()
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = "ALPHAV8S07\\SQLEX2008R2",
                InitialCatalog = "WooCommerce",
                UserID = "sa",
                Password = "sa"
            };

            var connection = new SqlConnection(connectionStringBuilder.ToString());
            await connection.OpenAsync();

            return connection;
        }
    }
}
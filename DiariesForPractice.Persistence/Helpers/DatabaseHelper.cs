using System.Data.SqlClient;
using System.Configuration;

namespace DiariesForPractice.Persistence.Helpers
{
	public static class DatabaseHelper
	{
		public static SqlConnection OpenConnection()
		{
			var connectionString = "";
			connectionString = ConfigurationManager.AppSettings["production"] == "true" 
				? ConfigurationManager.ConnectionStrings["DiariesForPractice"].ConnectionString
				: ConfigurationManager.ConnectionStrings["DiariesForPracticeLocal"].ConnectionString;
			var connection = new SqlConnection(connectionString);
			connection.Open();

			return connection;
		}

		public static void CloseConnection(SqlConnection connection)
		{
			connection.Close();
		}
	}
}
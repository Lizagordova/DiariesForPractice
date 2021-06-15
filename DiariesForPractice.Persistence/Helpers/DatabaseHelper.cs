using System.Data.SqlClient;
using System.Configuration;

namespace DiariesForPractice.Persistence.Helpers
{
	public static class DatabaseHelper
	{
		public static SqlConnection OpenConnection()
		{
			var connectionString = "";
			var test = ConfigurationManager.AppSettings["production"] == "true";
			/*connectionString = ConfigurationManager.AppSettings["production"] == "true" 
				? ConfigurationManager.ConnectionStrings["DiariesForPracticeProduction"].ConnectionString
				: ConfigurationManager.ConnectionStrings["DiariesForPracticeLocal"].ConnectionString;*/
			connectionString = @"Server=(local)\SQL2019;Initial Catalog=DiariesForPractice;User ID=sa;Password=Pr0metric!;";//todo: потом убрать
				 //userName="AspireAdmin" userPassword="456789" ownerName="BTL" ownerId="2" defaultTestProfileId="1">
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
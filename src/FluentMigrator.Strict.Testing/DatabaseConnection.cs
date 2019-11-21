using System.Data;
using System.Data.SqlClient;

namespace FluentMigrator.Strict.Testing
{
    public class DatabaseConnection
    {
        public const string ConnectionString = "Server=localhost; Database=Employees; Trusted_Connection=true";

        public static DataTable GetAllEmployees()
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sqlString = "Select concat(a.FirstName, ' ' , a.LastName) as Name, b.JobPosition, a.Salary, c.Amount " +
                                    "From Employees a " +
                                    "Left join JobPositions b on a.JobPositionId = b.Id " +
                                    "Left join Pensions c on a.PensionId = c.Id " +
                                    "Order by FirstName ";

                SqlCommand command = new SqlCommand(sqlString, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            return table;
        }

        public static void IncreaseAllPenions(int salaryPercentage)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            string sqlString = "Exec ContributeToPension @Percentage = @salaryPercentage";

            SqlCommand command = new SqlCommand(sqlString, connection);
            command.Parameters.Add("@salaryPercentage", SqlDbType.Int).Value = salaryPercentage;

            command.ExecuteNonQuery();

        }

        public static DataTable GetPensionContributions()
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sqlString = "Select concat(a.FirstName, ' ' , a.LastName) as Name, b.Amount, b.LastContribution " +
                                    "From Employees a " +
                                    "Left join Pensions b on a.PensionId = b.Id " +
                                    "Order by FirstName ";

                SqlCommand command = new SqlCommand(sqlString, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }

            return table;
        }

        public static DataTable GetEmployeesNamedSam()
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sqlString = "select * from Employees where FirstName = 'Sam' ";

                SqlCommand command = new SqlCommand(sqlString, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
            }
            return table;
        }

        public static void SetNonClusteredIndexOnFirstName()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sqlString = "create index INDX_FIRSTNAME ON EMPLOYEES (firstName)";

                SqlCommand command = new SqlCommand(sqlString, connection);
            }
        }

        public static void dropNonClusteredIndexOnFirstName()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sqlString = "drop index INDX_FIRSTNAME on employees";

                SqlCommand command = new SqlCommand(sqlString, connection);
            }
        }
    }
}

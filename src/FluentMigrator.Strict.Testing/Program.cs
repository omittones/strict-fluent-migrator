using System;
using System.Data;
using FluentMigrator.Runner;
using FluentMigrator.Strict.Testing.Migrations;

namespace FluentMigrator.Strict.Testing
{
    public class Program
    {
        static void Main(string[] args)
        {
            MigrationServiceProvider.ApplyMigrations();

            //PrintHomePage();
        }

        private static void PrintHomePage()
        {
            Console.Clear();
            Console.WriteLine("Employee Database");
            Console.WriteLine("1. Employee Overview Screen");
            Console.WriteLine("2. Contribute to Penions");
            Console.WriteLine("3. Get All Sam's Index Test");

            int option;
            int.TryParse(Console.ReadLine(), out option);

            if (option == 1)
            {
                PrintEmployeePage();
            }
            if (option == 2)
            {
                PrintContributionScreen();
            }
            if (option ==3)
            {
                PrintIndexTestScreen();
            }
            else
            {
                PrintHomePage();
            }
        }

        private static void PrintEmployeePage()
        {
            Console.Clear();
            var employeeTable = DatabaseConnection.GetAllEmployees();

            Console.WriteLine(("Name").PadRight(15) + " " + ("Job Position").PadRight(25) + " " + ("Salary").PadRight(15) + " Pension Fund");

            foreach (DataRow row in employeeTable.Rows)
            {
                var name = (row["Name"].ToString()).PadRight(15);
                var jobPosition = (row["JobPosition"].ToString()).PadRight(25);
                var salary = StringFormat.FormatMoney(row["Salary"].ToString());
                var pensionFund = StringFormat.FormatMoney(row["Amount"].ToString());

                Console.WriteLine($"{name} {jobPosition} {salary} {pensionFund}");
            }

            Console.ReadLine();
            PrintHomePage();
        }

        private static void PrintContributionScreen()
        {
            Console.Clear();
            Console.WriteLine("Salary Percentage to Contribute to Pension: ");
            int value = 0;
            int.TryParse(Console.ReadLine(), out value);

            if (value > 0)
            {
                DatabaseConnection.IncreaseAllPenions(value);
                Console.WriteLine("Contribution successfull");
                Console.WriteLine("Updated table as follows:");

                Console.WriteLine(("Name").PadRight(15) + " " + ("Pension Fund").PadRight(15) + " Last Contribution Made");

                var pensionTable = DatabaseConnection.GetPensionContributions();
                foreach (DataRow row in pensionTable.Rows)
                {
                    var name = (row["Name"].ToString()).PadRight(15);
                    var pensionFund = StringFormat.FormatMoney(row["Amount"].ToString());
                    var date = row["LastContribution"].ToString();

                    Console.WriteLine($"{name} {pensionFund} {date}");
                }

                Console.ReadLine();
                PrintHomePage();
            }
            else
            {
                Console.WriteLine("Percentage not valid, please try again");
                Console.ReadLine();
                PrintHomePage();
            }
        }

        private static void PrintIndexTestScreen()
        {
            Console.Clear();
            Console.WriteLine("Find All Sam's Test");

            var sw = new StopWatch();
            sw.Start();
            var employeeTable = DatabaseConnection.GetEmployeesNamedSam();
            sw.Stop();

            Console.WriteLine($"Clustered Index Scan on Employee_Id : {sw.ElapsedTime().Milliseconds}");
            Console.WriteLine("");

            DatabaseConnection.SetNonClusteredIndexOnFirstName();
            Console.WriteLine("Created Non Clustered Index on First Name");

            sw = new StopWatch();
            sw.Start();
            employeeTable = DatabaseConnection.GetEmployeesNamedSam();
            sw.Stop();

            Console.WriteLine($"NonClustered Index Seek on Employee_FirstName -> Key Lookup on Employee_Id : {sw.ElapsedTime().Milliseconds}");

            DatabaseConnection.dropNonClusteredIndexOnFirstName();

            Console.ReadLine();
            PrintHomePage();
        }
    }
}

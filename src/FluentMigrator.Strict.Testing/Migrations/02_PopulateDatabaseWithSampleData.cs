using System;
using FluentMigrator;

namespace FluentMigrator.Strict.Testing.Migrations
{
    [Migration(2)]
    public class PopulateDatabaseWithSampleData : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("JobPositions").Row(new { JobPosition = "Software Dev" });
            Insert.IntoTable("JobPositions").Row(new { JobPosition = "Project Manager" });
            Insert.IntoTable("JobPositions").Row(new { JobPosition = "Tester" });
            Insert.IntoTable("JobPositions").Row(new { JobPosition = "Business Analyst" });

            Insert.IntoTable("PensionProviders").Row(new { PensionProvider = "Pensions4U" });
            Insert.IntoTable("PensionProviders").Row(new { PensionProvider = "GoldenOldens" });
            Insert.IntoTable("PensionProviders").Row(new { PensionProvider = "PensionPower" });

            Insert.IntoTable("Pensions").Row(new { ProviderId = 1, Amount = 25000.00, LastContribution = DateTime.Today });
            Insert.IntoTable("Pensions").Row(new { ProviderId = 2, Amount = 20000.00, LastContribution = DateTime.Today });
            Insert.IntoTable("Pensions").Row(new { ProviderId = 3, Amount = 15000.00, LastContribution = DateTime.Today });

            Insert.IntoTable("Employees").Row(new { FirstName = "Wendy", LastName = "Williams", Age = 24, Salary = 15000.00, JobPositionId = 2, PensionId = 1 });
            Insert.IntoTable("Employees").Row(new { FirstName = "Rodger", LastName = "Rabbit", Age = 30, Salary = 28000.00, JobPositionId = 1, PensionId = 2 });
            Insert.IntoTable("Employees").Row(new { FirstName = "Peter", LastName = "Parker", Age = 26, Salary = 32000.00, JobPositionId = 3, PensionId = 3 });
            Insert.IntoTable("Employees").Row(new { FirstName = "Thomas", LastName = "Tank", Age = 21, Salary = 38000.00, JobPositionId = 4 });
            Insert.IntoTable("Employees").Row(new { FirstName = "Freddy", LastName = "Flint", Age = 35, Salary = 45000.00, JobPositionId = 1 });
        }

        public override void Down()
        {
            this.Delete.FromTable("Employees").AllRows();
            this.Delete.FromTable("Pensions").AllRows();
            this.Delete.FromTable("PensionProviders").AllRows();
            this.Delete.FromTable("JobPositions").AllRows();
        }
    }
}
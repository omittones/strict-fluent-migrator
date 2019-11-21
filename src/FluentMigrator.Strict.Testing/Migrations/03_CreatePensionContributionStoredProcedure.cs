using FluentMigrator;

namespace FluentMigrator.Strict.Testing.Migrations
{
    [Migration(3)]
    public class CreatePensionContributionStoredProcedure : Migration
    {
        public override void Up()
        {
            Execute.Sql(
                "CREATE PROCEDURE ContributeToPension @Percentage int " +
                "AS " +
                "UPDATE Pensions " +
                "Set Amount = (Amount + (Employees.Salary/100 * @Percentage)), LastContribution = GETDATE() " +
                "FROM Pensions " +
                "JOIN Employees on PensionId = Employees.PensionId "
                );
        }

        public override void Down()
        {
            Execute.Sql("drop procedure ContributeToPension");
        }
    }
}
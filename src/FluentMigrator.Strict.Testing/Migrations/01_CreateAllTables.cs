using FluentMigrator;

namespace FluentMigrator.Strict.Testing.Migrations
{
    [Migration(1)]
    public class CreateAllTables : Migration
    {
        public override void Down()
        {
            Delete.ForeignKey()
                .FromTable("Employees").ForeignColumn("JobPositionId")
                .ToTable("JobPositions").PrimaryColumn("Id");

            Delete.ForeignKey()
                .FromTable("Employees").ForeignColumn("PensionId")
                .ToTable("Pensions").PrimaryColumn("Id");

            Delete.ForeignKey()
                .FromTable("Pensions").ForeignColumn("ProviderId")
                .ToTable("PensionProviders").PrimaryColumn("Id");

            Delete.Table("Employees");
            Delete.Table("JobPositions");
            Delete.Table("PensionProviders");
            Delete.Table("Pensions");
        }
        public override void Up()
        {
            Create.Table("Employees")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity().NotNullable()
                .WithColumn("FirstName").AsString(255).NotNullable()
                .WithColumn("LastName").AsString(255).NotNullable()
                .WithColumn("Age").AsInt64().NotNullable()
                .WithColumn("Salary").AsDecimal(18, 0).NotNullable()
                .WithColumn("JobPositionId").AsInt64().Nullable()
                .WithColumn("PensionId").AsInt64().Nullable();


            Create.Table("JobPositions")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity().NotNullable()
                .WithColumn("JobPosition").AsString(255).NotNullable();

            Create.Table("PensionProviders")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity().NotNullable()
                .WithColumn("PensionProvider").AsString(255).NotNullable();

            Create.Table("Pensions")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity().NotNullable()
                .WithColumn("ProviderId").AsInt64().Nullable().WithDefaultValue(1)
                .WithColumn("Amount").AsDecimal(18, 0).NotNullable()
                .WithColumn("LastContribution").AsDate().Nullable();

            Create.ForeignKey()
                .FromTable("Employees").ForeignColumn("JobPositionId")
                .ToTable("JobPositions").PrimaryColumn("Id");

            Create.ForeignKey()
                .FromTable("Employees").ForeignColumn("PensionId")
                .ToTable("Pensions").PrimaryColumn("Id");

            Create.ForeignKey()
                .FromTable("Pensions").ForeignColumn("ProviderId")
                .ToTable("PensionProviders").PrimaryColumn("Id");
        }
    }

}
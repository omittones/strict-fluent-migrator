using FluentMigrator;
using System;

namespace FluentMigrator.Strict.Testing.Migrations
{
    [Migration(10)]
    public class AddCompanyTable : AutoReversingMigration
    {
        public override void Up()
        {
            this.Create.Table("Companies")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable();

            this.Insert.IntoTable("Companies")
                .Row(new { Name = "Shimano" })
                .Row(new { Name = "Bosch" });
        }
    }
}
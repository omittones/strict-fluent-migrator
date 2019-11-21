using FluentMigrator;

namespace FluentMigrator.Strict.Testing.Migrations
{
    [Migration(6)]
    public class AddCityTable : AutoReversingMigration
    {
        public override void Up()
        {
            this.Create.Table("Cities")
                .WithColumn("Id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable();
        }
    }
}

using System;
using FluentMigrator;

namespace FluentMigrator.Strict.Testing.Migrations
{
    [Migration(4)]
    public class IncreasePensionDataSet : Migration
    {
        public override void Up()
        {
            var rand = new Random();

            for (int i = 0; i < 5000; i++)
            {
                var pensionProvider = rand.Next(1, 4);
                var pensionAmount = rand.Next(15000, 95001);
                Insert.IntoTable("Pensions").Row(new { ProviderId = pensionProvider, Amount = pensionAmount, LastContribution = DateTime.Today });
            }
        }

        public override void Down()
        {
            this.Delete.FromTable("Pensions").AllRows();
        }
    }
}
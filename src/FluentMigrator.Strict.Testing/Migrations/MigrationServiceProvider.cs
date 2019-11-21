using Microsoft.Extensions.DependencyInjection;
using FluentMigrator.Runner;
using System;

namespace FluentMigrator.Strict.Testing.Migrations
{
    public class MigrationServiceProvider
    {
        public static void ApplyMigrations()
        {
            var serviceProvider = CreateServices();

            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
        }

        private static IServiceProvider CreateServices()
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(DatabaseConnection.ConnectionString)
                    .ScanIn(typeof(CreateAllTables).Assembly).For.Migrations())
                    .AddLogging(lb => lb.AddFluentMigratorConsole())
                    .BuildServiceProvider(false);
        }

        public static void UpdateDatabase(IServiceProvider provider)
        {
            var runner = provider.GetRequiredService<IMigrationRunner>();
            //runner.MigrateDown(0);
            runner.MigrateUp();
        }
    }
}

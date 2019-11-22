using FluentMigrator.Strict.Testing.Migrations;

namespace FluentMigrator.Strict.Testing
{
    public class Program
    {
        static void Main(string[] args)
        {
            MigrationServiceProvider.ApplyMigrations();
        }
    }
}
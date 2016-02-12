namespace SnapCot.Web.App_Start
{
    using SnapCot.Data;
    using SnapCot.Data.Migrations;
    using System.Data.Entity;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SnapCotDbContext, Configuration>());
            SnapCotDbContext.Create().Database.Initialize(true);
        }
    }
}
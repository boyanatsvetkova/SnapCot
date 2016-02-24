namespace SnapCot.Web.App_Start
{
    using System.Data.Entity;
    using SnapCot.Data;
    using SnapCot.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SnapCotDbContext, Configuration>());
            SnapCotDbContext.Create().Database.Initialize(true);
        }
    }
}
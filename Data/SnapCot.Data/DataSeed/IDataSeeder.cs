namespace SnapCot.Data.DataSeed
{
    using System.Data.Entity;

    public interface IDataSeeder
    {
        void SeedRoles();

        void SeedUsers();

        void SeedData();
    }
}

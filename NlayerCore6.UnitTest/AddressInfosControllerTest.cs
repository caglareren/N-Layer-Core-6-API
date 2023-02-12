using Microsoft.EntityFrameworkCore;
using NLayerCore6.Core;
using NLayerCore6.Repository;

namespace NLayerCore6.UnitTest
{
    public class AddressInfosControllerTest
    {
        protected DbContextOptions<AppDbContext> _contextOptions { get; private set; }

        public void SetContextOptions(DbContextOptions<AppDbContext> contextOptions)
        {
            _contextOptions = contextOptions;
            Seed();
        }

        public void Seed()
        {
            using (AppDbContext context = new(_contextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.AddressInfos.Add(new AddressInfo() { Id = 1, CityName = "Adana", CityCode = "01", DistrictName = "Ceyhan", ZipCode = "01920" });
                context.AddressInfos.Add(new AddressInfo() { Id = 2, CityName = "Ankara", CityCode = "06", DistrictName = "Çankaya", ZipCode = "06420" });
                context.AddressInfos.Add(new AddressInfo() { Id = 3, CityName = "Antalya", CityCode = "07", DistrictName = "Manavgat", ZipCode = "07330" });

                context.SaveChanges();
            }
        }

    }
}
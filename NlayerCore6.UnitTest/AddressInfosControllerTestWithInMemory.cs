using Microsoft.EntityFrameworkCore;
using NLayerCore6.Core;
using NLayerCore6.Repository;
using NLayerCore6.UnitTest;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NlayerCore6.UnitTest
{
    public class AddressInfosControllerTestWithInMemory : AddressInfosControllerTest
    {
        public AddressInfosControllerTestWithInMemory()
        {
            // SQLite InMemory
            //var connection = new SqliteConnection("DataSource=:memory:");
            //connection.Open();
            //SetContextOptions(new DbContextOptionsBuilder<AppDbContext>().UseSqlite(connection).Options);

            // SQL Server Express LocalDB InMemory
            //var sqlCon = @"Server=(localdb)\MSSQLLocalDB;Database=UnitTestInMemoryDB;Trusted_Connection=true; MultipleActiveResultSets=true";
            //SetContextOptions(new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(sqlCon).Options);

            // EF Core InMemory
            SetContextOptions(new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("UnitTestInMemoryDB").Options);
        }

        [Fact]
        public async Task Create()
        {
            var newItem = new AddressInfo { CityName = "Antalya", CityCode = "07", DistrictName = "Alanya", ZipCode = "07700" };
            using (var context = new AppDbContext(_contextOptions))
            {
                var result = await context.AddressInfos.AddAsync(newItem);

                context.SaveChanges();

                var item = context.AddressInfos.ToList().Count();

                Assert.Equal(4, item);
            }
        }


        [Fact]
        public async Task Where()
        {
            using (var context = new AppDbContext(_contextOptions))

            {
                int dbc = context.AddressInfos.Where(x => x.CityName == "Antalya").ToList().Count();

                Assert.Equal(1, dbc);
            }
        }

        [Theory]
        [InlineData(1)]
        public async Task Update(int id)
        {
            using (var context = new AppDbContext(_contextOptions))

            {
                var item = await context.AddressInfos.FindAsync(id);
                item.CityName = "Muğla";

                context.AddressInfos.Update(item);

                context.SaveChanges();

                var item2 = await context.AddressInfos.FindAsync(id);

                Assert.Equal("Muğla", item2.CityName);
            }
        }

        [Theory]
        [InlineData(1)]
        public async Task Delete(int id)
        {
            using (var context = new AppDbContext(_contextOptions))

            {
                var item = await context.AddressInfos.FindAsync(id);

                context.AddressInfos.Remove(item);

                context.SaveChanges();

                var item2 = context.AddressInfos.ToList().Count();

                Assert.Equal(2, item2);
            }
        }
    }
}
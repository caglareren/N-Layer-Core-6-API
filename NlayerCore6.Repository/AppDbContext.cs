using Microsoft.EntityFrameworkCore;
using NLayerCore6.Core;

namespace NLayerCore6.Repository
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AddressInfo> AddressInfos { get; set; }

    }
}

using Envanter.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Envanter.Server.Data
{
    public class EnvanterDbContext : DbContext
    {
        public EnvanterDbContext(DbContextOptions<EnvanterDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Personal> Personals { get; set; }
        public DbSet<WareData> WareDatas { get; set; }

        }
}

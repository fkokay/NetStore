using Microsoft.EntityFrameworkCore;
using NetStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.Infrastructure.Data
{
    public class NetStoreDbContext : DbContext
    {
        public NetStoreDbContext(DbContextOptions<NetStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

using ZeusERP.Entities.Concrete;

namespace ZeusERP.DataAccess.Contexts
{
    public class ZeusContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=desktop-rtotag4;Database=ZeusDB;Trusted_Connection = True; ");
        }
        public ZeusContext()
        {

        }
        public ZeusContext(DbContextOptions<ZeusContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

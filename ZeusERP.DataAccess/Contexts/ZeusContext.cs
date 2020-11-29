using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using ZeusERP.Core.Utilities;
using ZeusERP.Entities.Concrete;

namespace ZeusERP.DataAccess.Contexts
{
    public class ZeusContext : DbContext
    {
        public string ConnectionString { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<BillOfMaterials> BillOfMaterials { get; set; }
        public DbSet<BillOfMaterialsComponent> BillOfMaterialsComponent { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            try
            {
                ConnectionString = WebConfig.GetConfigItem("SaffetDB");
                Console.WriteLine(ConnectionString);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            optionsBuilder.UseSqlServer(ConnectionString);
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

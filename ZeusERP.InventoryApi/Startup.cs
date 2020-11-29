using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.SqlServer;

using ZeusERP.DataAccess.Contexts;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using ZeusERP.DataAccess.Abstract;
using ZeusERP.DataAccess.Concrete;
using ZeusERP.Business.Concrete;
using ZeusERP.Business.Abstract;

namespace ZeusERP.InventoryApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddDefaultPolicy(
                    builder => builder.AllowAnyOrigin()
                )
            );
            services.AddControllers();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDao, EfProductDao>();
            services.AddScoped<ICategoryDao, EfCategoryDao>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddDbContext<ZeusContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SaffetDB")));

            var x = Configuration.GetConnectionString("SaffetDB");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });


            
        }
    }
}

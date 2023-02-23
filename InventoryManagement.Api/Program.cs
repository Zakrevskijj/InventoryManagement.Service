using InventoryManagement.Application;
using InventoryManagement.Application.Interfaces;
using InventoryManagement.Core.Repositories;
using InventoryManagement.Infrastructure;
using InventoryManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            // Add services to the container.

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            // InMem DB
            //services.AddDbContext<InventoryContext>(c =>
            //    c.UseInMemoryDatabase("DbConnection"));

            //// Real DB
            services.AddDbContext<InventoryContext>(c =>
                c.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

            services.AddAutoMapper(typeof(Program));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IInventoriesRepository, InventoriesRepository>();
            services.AddScoped<ICompaniesRepository, CompaniesRepository>();

            // Add Application Layer
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IInventoriesService, InventoriesService>();


            var app = builder.Build();

            SeedDatabase(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static void SeedDatabase(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var inventoryContext = services.GetRequiredService<InventoryContext>();
                    var productService = services.GetRequiredService<IProductsService>();
                    InventoryContextSeed.SeedAsync(inventoryContext, productService).Wait();
                }
                catch (Exception exception)
                {
                    //Log here
                }
            }
        }
    }
}
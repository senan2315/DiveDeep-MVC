using DeepDive11.Data;
using DeepDive11.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DeepDive11
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<DeepDiveContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
        /*
        protected readonly string _connectionString;
        protected Program(IConfiguration configuration)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                     .AddJsonFile("appsettings.Development.json")
                     .Build();

            string conn1 = config.GetConnectionString("Connection1") + ";Connect Timeout=2";
            string conn2 = config.GetConnectionString("Connection2") + ";Connect Timeout=2";
            string conn3 = config.GetConnectionString("Connection3");
            try
            {
                using var conn = new SqlConnection(conn1);
                conn.Open();
                _connectionString = conn1;
            }
            catch
            {
                try
                {
                    using var conn = new SqlConnection(conn2);
                    conn.Open();
                    _connectionString = conn2;
                }
                catch
                {
                    _connectionString = conn3;
                }
            }
        }
        */
    }
}

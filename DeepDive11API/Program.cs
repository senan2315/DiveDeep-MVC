using Microsoft.EntityFrameworkCore;
using DeepDive11.Persistence;
using Microsoft.AspNetCore.Builder;
using DeepDive11;
using DeepDive11.Data;
using Scalar.AspNetCore;
using DeepDive11.Models;
using Microsoft.AspNetCore.Identity;


namespace DeepDive11API
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
            
            builder.Services.AddIdentityApiEndpoints<ApplicationUser>().AddEntityFrameworkStores<DeepDiveContext>(); // tilføjelse af Identity API Endpoints

            builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();
            // Add services to the container.

            builder.Services.AddCors(options => // tilføjelse af CORS policy
            {
                options.AddPolicy("AllowMobileApp", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); 
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowMobileApp"); // tilføjelse af CORS middleware

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.MapIdentityApi<ApplicationUser>(); // tilføjelse af Identity API Endpoints

            app.Run();
        }
    }
}

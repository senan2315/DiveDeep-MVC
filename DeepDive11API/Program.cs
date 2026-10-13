using Microsoft.EntityFrameworkCore;
using DeepDive11.Persistence;
using DeepDive11.Data;
using DeepDive11.Models;
using Microsoft.AspNetCore.Identity;
using Scalar.AspNetCore;

namespace DeepDive11API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Database
            builder.Services.AddDbContext<DeepDiveContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Identity med Bearer Token og roller
            builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DeepDiveContext>();

            // Repositories
            builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();

            // CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowMobileApp", policy =>
                {
                    policy.WithOrigins("https://localhost:7240", "https://localhost:7039")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // Controllers og OpenAPI
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            // Authorization
            builder.Services.AddAuthorization();

            var app = builder.Build();

            // Development
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowMobileApp");

            app.UseAuthentication();
            app.UseAuthorization();

            // Controllers
            app.MapControllers();

            // Identity API Endpoints
            app.MapIdentityApi<ApplicationUser>();

            // Claims endpoint
            app.MapGet("/claims", (HttpContext context) =>
            {
                var claims = context.User.Claims.Select(c => new
                {
                    c.Type,
                    c.Value
                });

                return Results.Ok(claims);
            })
            .RequireAuthorization()
            .RequireCors("AllowMobileApp");

            app.Run();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using BackEnd.Data;
using BackEnd.Repository;
using BackEnd.Repository;
using BackEnd.Services;
using BackEnd.Services;
using BackEnd.Middleware;

namespace BackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // DbContext registration
            builder.Services.AddDbContext<BackEndContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("BackEndContext")
                    ?? throw new InvalidOperationException("Connection string 'BackEndContext' not found.")
                ));

            // Repository + Service registration
            builder.Services.AddScoped<IDestinationRepository, DestinationRepository>();
            builder.Services.AddScoped<IDestinationService, DestinationService>();

            // Controllers + Swagger
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure middleware
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Global exception handling middleware
            app.UseMiddleware<ExceptionMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
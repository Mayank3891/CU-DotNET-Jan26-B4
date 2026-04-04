
using FrontEnd.Services;

namespace FrontEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddHttpClient<ITravelService, TravelService>(client =>
            {
                
                client.BaseAddress = new Uri("https://localhost:7037/");
            });

            
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Travel}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
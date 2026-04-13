using azurefront.Services;

namespace azurefront
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ✅ Add MVC
            builder.Services.AddControllersWithViews();

            // ✅ ADD THIS (VERY IMPORTANT FIX)
            builder.Services.AddHttpClient<StudentService>(client =>
            {
                client.BaseAddress = new Uri("https://webback20260413152654-fzcugfetdrgpafe7.centralindia-01.azurewebsites.net");
                // Example:
                // client.BaseAddress = new Uri("https://studentapi.azurewebsites.net/");
            });

            var app = builder.Build();

            // Pipeline
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
                pattern: "{controller=Students}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
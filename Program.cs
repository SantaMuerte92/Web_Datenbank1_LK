using Web_Datenbank1_LK.BL;
using Web_Datenbank1_LK.DAL;

namespace Web_TagHelper
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IPersonRepository, PersonRepository>();

            builder.Services.AddScoped<IPersonService, PersonService>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");



            app.Run();
        }
    }
}

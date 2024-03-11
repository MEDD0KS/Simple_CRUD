namespace Simple_CRUD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            var app = builder.Build();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.MapControllerRoute(name: "default", pattern: "{controller}/{action}/{id?}");

            app.MapGet("/", () => "1");
            


            app.Run();
            
        }
    }
}

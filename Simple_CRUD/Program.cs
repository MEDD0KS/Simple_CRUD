using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Simple_CRUD.Domain.Entities;
using Simple_CRUD.Infrastructure.Database;
using Simple_CRUD.Infrastructure.Repositories;
using Simple_CRUD.Application.Services;
using System;

namespace Simple_CRUD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Release", Version = "v1" });
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddDbContext<GameContext>();
            builder.Services.AddScoped<IGameRepository,GameRepository>();
            builder.Services.AddScoped<IGameService, GameService>();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.MapControllerRoute(name: "default", pattern: "{controller}/{action}/{id?}");

            app.MapGet("/", () => "1");
            


            app.Run();
            
        }
    }
}

//using System.Security.Cryptography.Xml;
using System;
using DataLayer.EF;
using Microsoft.OpenApi.Models;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Knowledge_Base.Interfaces;
using Knowledge_Base.Services;
using DataLayer.Entities;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Interfaces;

namespace Knowledge_Base
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string host = Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("POSTGRES_PORT") ?? "5432";
            string database = Environment.GetEnvironmentVariable("POSTGRES_DB") ?? "KnowledgeBase";
            string userName = Environment.GetEnvironmentVariable("POSTGRES_USER") ?? "postgres";
            string password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? "DefaultPassword";
            string connection = $"Host={host};Port={port};Database={database};Username={userName};Password={password};";
            builder.Services.AddControllers();
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(cfg => cfg.UseNpgsql(connectionString ?? connection));
            builder.Services.AddSingleton<IMarkdown, MarkdownService>();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddScoped<IRepository<Note>, NoteRepository>();
            builder.Services.AddScoped<IRepository<Reference>, ReferenceRepository>();
            builder.Services.AddScoped<INoteService, NoteService>();
            builder.Services.AddSwaggerGen(cfg =>
            {
                cfg.SwaggerDoc("v1", new OpenApiInfo { Title = "Notes", Version = "v1", });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "Notes"));
                app.UseRouting();
                app.UseEndpoints(endpoints => endpoints.MapControllers());
            }

            app.UseHttpsRedirection();
            app.Logger.LogInformation(connection);

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Note}/{action=All}/{id?}"
                );

            app.Run();
        }
    }
}
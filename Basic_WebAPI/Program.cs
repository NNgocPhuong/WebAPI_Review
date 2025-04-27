
using Basic_WebAPI.Data;
using Basic_WebAPI.IService;
using Basic_WebAPI.Repositories;
using Basic_WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace Basic_WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddDbContext<VideoGameDbContext>(option
                => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<VideoGameRepository>();
            builder.Services.AddScoped<IVideoGameService, VideoGameService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapScalarApiReference();
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

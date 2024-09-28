
using DarKnightAndJoker.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace DarKnightAndJoker.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var configuration = builder.Configuration;
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<DarKnightDbContext>(options =>
            options.UseSqlServer(connectionString));

            builder.Services.AddCors(options => options.AddPolicy("AllowWebApp", builder =>
            builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()));

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowWebApp");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}

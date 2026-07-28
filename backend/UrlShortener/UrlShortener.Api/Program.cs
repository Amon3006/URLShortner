using MongoDB.Driver;
using UrlShortener.Api.Configurations;
using UrlShortener.Api.Data;
using UrlShortener.Api.Repository;
using UrlShortener.Api.Services;
using UrlShortener.Api.Services.Interfaces;
namespace UrlShortener.Api
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

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("React", policy =>
                {
                    policy.WithOrigins("http://localhost:5173")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // Configure MongoDB settings

            builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
            builder.Services.AddSingleton<MongoDbContext>();
            builder.Services.AddScoped<IUrlRepository, UrlRepository>();

            builder.Services.AddScoped<IUrlService, UrlService>();

            builder.Services.AddScoped<IShortCodeGenerator, ShortCodeGenerator>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("React");

            app.MapControllers();

            app.Run();
        }
    }
}

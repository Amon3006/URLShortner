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
                    policy.WithOrigins("http://localhost:5173","https://url-shortner-ten-omega.vercel.app","https://url-shortner-git-main-shashank-06d4.vercel.app","https://url-shortner-nine-rouge.vercel.app")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // Configure MongoDB settings

            builder.Services.Configure<MongoDbSettings>(
     options =>
     {
         options.ConnectionString =
             Environment.GetEnvironmentVariable("MONGODB_URI");

         options.DatabaseName =
             Environment.GetEnvironmentVariable("DATABASE_NAME");
     });
            builder.Services.AddSingleton<MongoDbContext>();
            builder.Services.AddScoped<IUrlRepository, UrlRepository>();

            builder.Services.AddScoped<IUrlService, UrlService>();

            builder.Services.AddScoped<IShortCodeGenerator, ShortCodeGenerator>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
                app.UseSwagger();
                app.UseSwaggerUI();
            

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("React");

            app.MapControllers();

            app.Run();
        }
    }
}

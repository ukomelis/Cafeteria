global using CafeteriaAPI.Postgre;
global using CafeteriaAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaAPI
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

            //Add cors
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            // Add Postgre
            builder.Services.AddDbContext<CafeteriaContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));

            // Add Services
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ISalesService, SalesService>();
            builder.Services.AddScoped<ICashierService, CashierService>();

            var app = builder.Build();

            app.UseCors("AllowAll");

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
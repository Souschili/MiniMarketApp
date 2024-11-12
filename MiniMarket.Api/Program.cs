using Microsoft.EntityFrameworkCore;
using MiniMarket.Domain;
using MiniMarket.Domain.Context;
using MiniMarket.Domain.Repositories;
using MiniMarket.Domain.Repositories.Contract;

namespace MiniMarket.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<MiniMarketDbContext>(cfg =>
             cfg.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            builder.Services.AddScoped<ICartRepo, CartRepo>();
            builder.Services.AddScoped<ICartItemRepo, CartItemRepo>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            try
            {
                // временный костыль для создания БД 
                using var scope = app.Services.CreateScope();
                var service = scope.ServiceProvider.GetRequiredService<MiniMarketDbContext>();
                service.Database.EnsureCreated();
                await SeedDb.StartSeedAsync(service);
            }
            catch (Exception ex) { 
            
                Console.Error.WriteLine(ex.Message);
                throw;
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

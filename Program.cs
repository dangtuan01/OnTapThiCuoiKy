
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using OnTapThiCuoiKy.Contexts;
using OnTapThiCuoiKy.Services.ProviderService.Implements;
using OnTapThiCuoiKy.Services.ProviderService.Interfaces;
using OnTapThiCuoiKy.Services.ShopService.Implements;
using OnTapThiCuoiKy.Services.ShopService.Interfaces;

namespace OnTapThiCuoiKy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IShopService, ShopService>();
            builder.Services.AddScoped<IProviderService, ProviderService>();
            var app = builder.Build();

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
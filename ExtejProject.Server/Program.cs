
using ExtejProject.ApplicationCore.Interfaces;
using ExtejProject.ApplicationCore.Services;
using ExtejProject.Infrastructure.Data;
using ExtejProject.Server.Extensions;
using ExtejProject.Server.Seeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExtejProject.Server
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddCoreServices(builder.Configuration,builder.Environment);
			builder.Services.RegisterServices();

			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowSpecificOrigin",
					builder => builder
						.WithOrigins("https://localhost:4200")
						.AllowAnyMethod()
						.AllowAnyHeader()
						.AllowCredentials());
			});
			var app = builder.Build();

			app.UseDefaultFiles();
			app.UseStaticFiles();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}


			app.UseDefaultFiles();
			app.UseStaticFiles();


			app.UseCors(u => u.AllowAnyHeader().AllowAnyMethod()
			.AllowCredentials()
			.WithOrigins("https://localhost:4200", "http://localhost:4200"));

			app.MapFallbackToController("Index", "Fallback");

			app.UseHttpsRedirection();

			app.UseAuthorization();

		

			app.MapControllers();

			


			using (var scope = app.Services.CreateScope())
			{
				var services = scope.ServiceProvider;

				try
				{
					var db = services.GetRequiredService<ApplicationDbContext>();
					var seedService = services.GetRequiredService<ISeedService>();
					var pending = await db.Database.GetPendingMigrationsAsync();
				
					if (pending.Count() > 0)
					{
						await db.Database.MigrateAsync();
						var logger = services.GetService<ILogger<Program>>();
						logger.LogInformation("Migration Successfull");
						await AppSeed.SeedProcess(seedService);

					}
					
				}
				catch (Exception ex)
				{
					var logger = services.GetService<ILogger<Program>>();
					logger.LogError(ex, "An Error Occurred during Migration");
				}

			}

			app.Run();
		}
	}
}

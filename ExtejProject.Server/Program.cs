
using ExtejProject.ApplicationCore.Interfaces;
using ExtejProject.ApplicationCore.Services;
using ExtejProject.Infrastructure.Data;
using ExtejProject.Server.Extensions;
using ExtejProject.Server.Seeds;
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

			builder.Services.AddSwaggerGen();
			builder.Services.AddCoreServices(builder.Configuration, builder.Environment);
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
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddHttpContextAccessor();
			var app = builder.Build();


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

			app.UseAuthentication();
			app.UseAuthorization();



			app.MapControllers();




			using (var scope = app.Services.CreateScope())
			{
				var services = scope.ServiceProvider;

				try
				{
					var db = services.GetRequiredService<ApplicationDbContext>();

					var environment = services.GetRequiredService<IWebHostEnvironment>();

					var connectionString = db.Database.GetDbConnection().ConnectionString;

					var pending = await db.Database.GetPendingMigrationsAsync();
					var logger = services.GetService<ILogger<Program>>();

					if (pending.Count() > 0)
					{

						await db.Database.MigrateAsync();
						var seedService = services.GetRequiredService<ISeedService>();

						await AppSeed.SeedProcess(seedService);

					}
					else
					{
						logger.LogInformation("No Migrations Pending");
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

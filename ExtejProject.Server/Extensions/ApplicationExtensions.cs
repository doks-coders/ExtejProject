using ExtejProject.Infrastructure.Data;
using ExtejProject.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ExtejProject.Server.Extensions
{
	public static class ApplicationExtensions
	{
		public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration config, IWebHostEnvironment environment)
		{
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			var connString = "";
			if (environment.IsDevelopment())
			{
				connString = config.GetConnectionString("DefaultConnection");
			}
			else
			{
				// Use connection string provided at runtime by FlyIO.
				var connUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
				Console.WriteLine(connUrl);
				// Parse connection URL to connection string for Npgsql
				connUrl = connUrl.Replace("postgres://", string.Empty);
				var pgUserPass = connUrl.Split("@")[0];
				var pgHostPortDb = connUrl.Split("@")[1];
				var pgHostPort = pgHostPortDb.Split("/")[0];
				var pgDb = pgHostPortDb.Split("/")[1];
				var pgUser = pgUserPass.Split(":")[0];
				var pgPass = pgUserPass.Split(":")[1];
				var pgHost = pgHostPort.Split(":")[0];
				var pgPort = pgHostPort.Split(":")[1];
				var updatedHost = pgHost.Replace("flycast", "internal");

				connString = $"Server={updatedHost};Port={pgPort};User Id={pgUser};Password={pgPass};Database={pgDb};";
			}

			services.AddDbContext<ApplicationDbContext>(opt =>
			{
				opt.UseNpgsql(connString);
			});
			return services;
		}
	}
}

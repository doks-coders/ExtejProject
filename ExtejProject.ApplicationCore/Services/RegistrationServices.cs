using ExtejProject.ApplicationCore.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ExtejProject.ApplicationCore.Services
{
	public static class RegistrationServices
	{
		public static IServiceCollection RegisterServices(this IServiceCollection services)
		{
			services.AddScoped<ISeedService, SeedService>();
			services.AddScoped<IWalletService, WalletService>();
			return services;
		}
	}
}

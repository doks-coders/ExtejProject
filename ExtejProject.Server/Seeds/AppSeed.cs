using ExtejProject.ApplicationCore.Interfaces;

namespace ExtejProject.Server.Seeds
{
	public class AppSeed
	{
		public static async Task SeedProcess(ISeedService seed)
		{
			await seed.SeedCryptoCurrencies();
			await seed.SeedUser();
			await seed.SeedTransactions();
			await seed.SeedCards();
		}
	}
}

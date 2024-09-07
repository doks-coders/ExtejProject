using ExtejProject.ApplicationCore.Interfaces;

namespace ExtejProject.Server.Seeds
{
	public class AppSeed
	{
		//This process is used when the database is empty
		public static async Task SeedProcess(ISeedService seed)
		{
			await seed.SeedCryptoCurrencies();
			await seed.SeedUser();
			await seed.SeedTransactions();
			await seed.SeedCards();
		}
	}
}

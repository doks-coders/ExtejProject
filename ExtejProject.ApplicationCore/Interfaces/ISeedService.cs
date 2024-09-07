namespace ExtejProject.ApplicationCore.Interfaces
{
	public interface ISeedService
	{
		Task SeedCryptoCurrencies();
		Task SeedTransactions();
		Task SeedCards();
		Task SeedUser();

	}
}

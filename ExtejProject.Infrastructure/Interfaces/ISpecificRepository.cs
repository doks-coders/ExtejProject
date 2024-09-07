using ExtejProject.SharedModels.Entities;

namespace ExtejProject.Infrastructure.Interfaces
{
	public interface ICryptoCurrencyRepository : IBaseRepository<CryptoCurrency>
	{

	}

	public interface ITransactionRepository : IBaseRepository<Transaction>
	{

	}


	public interface IApplicationUserRepository : IBaseRepository<ApplicationUser>
	{

	}
	public interface IAccountCardRepository : IBaseRepository<AccountCard>
	{

	}
}

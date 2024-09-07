using ExtejProject.Infrastructure.Data;
using ExtejProject.Infrastructure.Interfaces;
using ExtejProject.SharedModels.Entities;

namespace ExtejProject.Infrastructure.Repositories
{
	public class CryptoCurrencyRepository : BaseRepository<CryptoCurrency>, ICryptoCurrencyRepository
	{
		public CryptoCurrencyRepository(ApplicationDbContext context) : base(context)
		{
		}
	}


	public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
	{
		public TransactionRepository(ApplicationDbContext context) : base(context)
		{
		}
	}


	public class ApplicationUserRepository : BaseRepository<ApplicationUser>, IApplicationUserRepository
	{
		public ApplicationUserRepository(ApplicationDbContext context) : base(context)
		{
		}
	}

	public class AccountCardRepository : BaseRepository<AccountCard>, IAccountCardRepository
	{
		public AccountCardRepository(ApplicationDbContext context) : base(context)
		{
		}
	}


}

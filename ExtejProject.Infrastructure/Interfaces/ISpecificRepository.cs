using ExtejProject.SharedModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

﻿using ExtejProject.Infrastructure.Data;
using ExtejProject.Infrastructure.Interfaces;
using ExtejProject.SharedModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtejProject.Infrastructure.Repositories
{
	public class CryptoCurrencyRepository : BaseRepository<CryptoCurrency>, ICryptoCurrencyRepository
	{
		public CryptoCurrencyRepository(ApplicationDbContext context) : base(context)
		{
		}
	}

	public interface ICryptoCurrencyRepository:IBaseRepository<CryptoCurrency>
	{

	}



	public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
	{
		public TransactionRepository(ApplicationDbContext context) : base(context)
		{
		}
	}

	public interface ITransactionRepository : IBaseRepository<Transaction>
	{

	}



	public class ApplicationUserRepository : BaseRepository<ApplicationUser>, IApplicationUserRepository
	{
		public ApplicationUserRepository(ApplicationDbContext context) : base(context)
		{
		}
	}

	public interface IApplicationUserRepository : IBaseRepository<ApplicationUser>
	{

	}


	public class AccountCardRepository : BaseRepository<AccountCard>, IAccountCardRepository
	{
		public AccountCardRepository(ApplicationDbContext context) : base(context)
		{
		}
	}

	public interface IAccountCardRepository : IBaseRepository<AccountCard>
	{

	}
}

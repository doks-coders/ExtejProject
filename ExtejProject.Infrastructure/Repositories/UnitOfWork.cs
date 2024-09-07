using ExtejProject.Infrastructure.Data;
using ExtejProject.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtejProject.Infrastructure.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		public ICryptoCurrencyRepository CryptoCurrency { get; set; }
		public ITransactionRepository Transaction { get; set; }
		public IApplicationUserRepository ApplicationUser { get; set; }
		public IAccountCardRepository AccountCard { get; set; }
		private readonly ApplicationDbContext _db;
		public UnitOfWork(ApplicationDbContext db)
		{
			CryptoCurrency = new CryptoCurrencyRepository(db);
			Transaction = new TransactionRepository(db);
			ApplicationUser = new ApplicationUserRepository(db);
			AccountCard = new AccountCardRepository(db);
			_db = db;
		}

		public async Task<bool> Save()
		{
			return 0 < await _db.SaveChangesAsync();
		}
	}

	public interface IUnitOfWork
	{
		public ITransactionRepository Transaction { get; set; }
		public ICryptoCurrencyRepository CryptoCurrency { get; set; }
		public IApplicationUserRepository ApplicationUser { get; set; }
		public IAccountCardRepository AccountCard { get; set; }

		Task<bool> Save();
	}
}

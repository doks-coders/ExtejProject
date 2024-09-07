using ExtejProject.ApplicationCore.Interfaces;
using ExtejProject.Infrastructure.Repositories;
using ExtejProject.SharedModels.Entities;
using ExtejProject.SharedModels.Extensions;
using ExtejProject.SharedModels.Responses;

namespace ExtejProject.ApplicationCore.Services
{
	public class WalletService : IWalletService
	{
		private readonly IUnitOfWork _unitOfWork;

		public WalletService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}


		//Gets the Seeded user from the database
		public async Task<ApplicationUser> GetUser()
		{
			var users = await _unitOfWork.ApplicationUser.GetItems(u => u.Id != null);
			var user = users.FirstOrDefault();
			if (user.Id != null) return user;
			throw new Exception("No User");
		}

		//Get all the Crypto that the default user has
		public async Task<List<CryptoBalanceResponse>> GetMyCrypto()
		{
			var user = await GetUser();

			var cryptos = await _unitOfWork.CryptoCurrency.GetItems(u => u.Id != null, includeProperties: "Transactions");

			var responses = cryptos.Select(u =>
			{
				var holdings = u.Transactions.Where(u => u.Status == "Recieved" && u.ApplicationUserId == user.Id).Sum(u => u.CryptoAmount);
				return new CryptoBalanceResponse()
				{
					TotalBalance = holdings * u.RateIntervals.GetCurrentPrice(),
					Name = u.Name,
				};
			}).ToList();

			return responses.Where(u => u.TotalBalance > 0).ToList();
		}



		//Get the price of all Fiat,total of Crypto and the total sum of both
		public async Task<TotalPricesResponse> GetTotalPrices()
		{
			var myCrypto = await GetMyCrypto();

			var cryptoSum = myCrypto.Sum(u => u.TotalBalance);
			var user = await GetUser();
			var fiat = user.AllocatedPrice;

			var total = cryptoSum + (double)fiat;
			var response = new TotalPricesResponse()
			{
				Fiat = (double)fiat,
				Crypto = cryptoSum,
				Total = total
			};
			return response;
		}

		//This gets all the information for available cryptos
		public async Task<IEnumerable<CryptoInfoResponse>> GetCryptoInformation()
		{
			var user = await GetUser();
			var cryptos = await _unitOfWork.CryptoCurrency.GetItems(u => u.Id != null, includeProperties: "Transactions");

			var responses = cryptos.Select(u => new CryptoInfoResponse()
			{
				ChangeRate = u.RateIntervals.GetChangeRate(),
				CurrentPrice = u.RateIntervals.GetCurrentPrice(),
				Holdings = u.Transactions.Where(u => u.Status == "Recieved" && u.ApplicationUserId == user.Id).Sum(u => u.CryptoAmount),
				Name = u.Name,
				NickName = u.NickName,
				RateIntervals = u.RateIntervals

			}).ToList();

			return responses;
		}


		//This returns the Account Cards of the default user
		public async Task<IEnumerable<CardResponse>> GetMyCards()
		{
			var user = await GetUser();
			var userId = user.Id;
			var cards = await _unitOfWork.AccountCard.GetItems(u => u.ApplicationUserId == userId);

			var response = cards.Select(cards =>
			{
				string debitNumber = cards.DebitNumber.ToString();
				int length = debitNumber.Count();

				return new CardResponse()
				{
					DebitNumber = "****" + debitNumber.Substring(length - 5, 4),
					Name = cards.Name,
				};
			});

			return response;
		}

		//Get all transactions for the default user
		public async Task<IEnumerable<TransactionResponse>> GetMyTransactions()
		{
			var user = await GetUser();
			var userId = user.Id;
			var transactions = await _unitOfWork.Transaction.GetItems(u => u.ApplicationUserId == userId, includeProperties: "Crypto");
			var responses = transactions.Select(u =>
			{
				string transactionLink = u.TransactionLink;
				int length = transactionLink.Length;
				return new TransactionResponse()
				{
					Status = u.Status,
					Amount = u.Amount,
					Created = u.Created,
					CryptoAmount = u.CryptoAmount,
					CryptoName = u.Crypto.Name,
					TransactionLink = transactionLink.Substring(0, 4) + "..." + transactionLink.Substring(length - 5, 4),
					_24hrRate = u.Crypto.RateIntervals.GetChangeRate24hr(),
					_7hrRate = u.Crypto.RateIntervals.GetChangeRate7hr()
				};

			});



			return responses;
		}
	}
}

using ExtejProject.ApplicationCore.Interfaces;
using ExtejProject.Infrastructure.Repositories;
using ExtejProject.SharedModels.Entities;
using ExtejProject.SharedModels.Extensions;
using System.Text.Json;

namespace ExtejProject.ApplicationCore.Services
{
	public class SeedService : ISeedService
	{
		private readonly IUnitOfWork _unitOfWork;

		public SeedService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		//This method is used for adding cryptocurrencies to the database
		public async Task SeedCryptoCurrencies()
		{

			var bitcoinIntervals = GetDailyData();
			var bitcoin = new CryptoCurrency()
			{
				NickName = "BTC",
				RateIntervals = bitcoinIntervals,
				Name = "Bitcoin",
			};


			var ethereumIntervals = GetDailyData();
			var ethereum = new CryptoCurrency()
			{
				NickName = "ETH",
				RateIntervals = ethereumIntervals,
				Name = "Ethereum",
			};

			var binanceIntervals = GetDailyData();
			var binance = new CryptoCurrency()
			{
				NickName = "BIN",
				RateIntervals = binanceIntervals,
				Name = "Binance Coin",
			};

			var usdCoinIntervals = GetDailyData();
			var usdCoin = new CryptoCurrency()
			{
				NickName = "USD",
				RateIntervals = usdCoinIntervals,
				Name = "USD Coin",
			};


			var rippleIntervals = GetDailyData();
			var ripple = new CryptoCurrency()
			{
				NickName = "XRP",
				RateIntervals = rippleIntervals,
				Name = "Ripple",
			};



			List<CryptoCurrency> cryptos = new() { bitcoin, ethereum, usdCoin, ripple, binance };
			await _unitOfWork.CryptoCurrency.AddItems(cryptos);
		}

		//Adds a default user
		public async Task SeedUser()
		{
			await _unitOfWork.ApplicationUser.AddItem(new ApplicationUser()
			{
				FullName = "Daniel Odokuma",
				JobRole = "Backend Developer",
				AllocatedPrice = 500000
			});
		}

		//Adds transactions to the database. These transactions will be linked to the total amount of available cryptos
		public async Task SeedTransactions()
		{
			var currencies = await _unitOfWork.CryptoCurrency.GetItems(u => u.Id != null);
			var users = await _unitOfWork.ApplicationUser.GetItems(u => u.Id != null);
			var bitcoin = currencies.Where(u => u.Name == "Bitcoin").FirstOrDefault();
			var usdCoin = currencies.Where(u => u.Name == "USD Coin").FirstOrDefault();
			var ethereum = currencies.Where(u => u.Name == "Ethereum").FirstOrDefault();
			var binance = currencies.Where(u => u.Name == "Binance Coin").FirstOrDefault();
			var user = users.FirstOrDefault();
			if (user != null)
			{
				var transactions = new List<Transaction>()
			{
				new Transaction()
				{
					Status="Recieved",
					Amount=21832,
					CryptoAmount=21832/bitcoin.RateIntervals.GetCurrentPrice(),
					CryptoId = bitcoin.Id,
					TransactionLink = Guid.NewGuid().ToString("N").Substring(0, 12),
					ApplicationUserId = user.Id
				},

				new Transaction()
				{
					Status="Recieved",
					Amount=21832,
					CryptoAmount=21832/ethereum.RateIntervals.GetCurrentPrice(),
					CryptoId = ethereum.Id,
					TransactionLink = Guid.NewGuid().ToString("N").Substring(0, 12),
					ApplicationUserId = user.Id
				},


				new Transaction()
				{
					Status="Recieved",
					Amount=239491,
					CryptoAmount=239491/ethereum.RateIntervals.GetCurrentPrice(),
					CryptoId = ethereum.Id,
					TransactionLink = Guid.NewGuid().ToString("N").Substring(0, 12),
					ApplicationUserId = user.Id
				},



				new Transaction()
				{
					Status="Sent",
					Amount=67878,
					CryptoAmount=67878/ethereum.RateIntervals.GetCurrentPrice(),
					CryptoId = ethereum.Id,
					TransactionLink = Guid.NewGuid().ToString("N").Substring(0, 12),
					ApplicationUserId = user.Id
				},

				new Transaction()
				{
					Status="Recieved",
					Amount=4783782,
					CryptoAmount=4783782/ethereum.RateIntervals.GetCurrentPrice(),
					CryptoId = ethereum.Id,
					TransactionLink = Guid.NewGuid().ToString("N").Substring(0, 12),
					ApplicationUserId = user.Id
				},
				new Transaction()
				{
					Status="Recieved",
					Amount=3899302,
					CryptoAmount=3783782/bitcoin.RateIntervals.GetCurrentPrice(),
					CryptoId = bitcoin.Id,
					TransactionLink = Guid.NewGuid().ToString("N").Substring(0, 12),
					ApplicationUserId = user.Id
				},
				new Transaction()
				{
					Status="Recieved",
					Amount=3289894,
					CryptoAmount=3289894/usdCoin.RateIntervals.GetCurrentPrice(),
					CryptoId = usdCoin.Id,
					TransactionLink = Guid.NewGuid().ToString("N").Substring(0, 12),
					ApplicationUserId = user.Id
				},

				new Transaction()
				{
					Status="Recieved",
					Amount=9090232,
					CryptoAmount=9090232/binance.RateIntervals.GetCurrentPrice(),
					CryptoId = binance.Id,
					TransactionLink = Guid.NewGuid().ToString("N").Substring(0, 12),
					ApplicationUserId = user.Id
				}
			};

				await _unitOfWork.Transaction.AddItems(transactions);
			}


		}

	
		//Adds Account Cards to Database
		public async Task SeedCards()
		{
			var users = await _unitOfWork.ApplicationUser.GetItems(u => u.Id != null);

			var user = users.FirstOrDefault();
			if (user == null) throw new Exception();
			List<AccountCard> accountCards = new List<AccountCard>() {
				new AccountCard()
				{
					ApplicationUserId = user.Id,
					DebitNumber = 167456789123442,
					Name = "Mastercard"
				},
				new AccountCard()
				{
						ApplicationUserId = user.Id,
					DebitNumber = 123456789123432,
					Name = "Visa"
				},
				new AccountCard()
				{
					  	ApplicationUserId = user.Id,
					DebitNumber = 132454645442442,
					Name = "American Express"
				},
				new AccountCard()
				{   ApplicationUserId = user.Id,
					DebitNumber = 142435354647632,
					Name = "Discover Financial"
				}
			};

			await _unitOfWork.AccountCard.AddItems(accountCards);
		}

		
		//This generates the 26hrs of prices changes for each crypto currency
		private string GetDailyData()
		{
			int hours = 25;
			List<object> objectList = new List<object>();

			for (int i = 0; i < hours; i++)
			{
				int hour = i + 1;
				int rate = GetRandomNumber(10000, 30000);
				objectList.Add(new { hour, rate = Math.Round((double)rate) });
			}

			return JsonSerializer.Serialize(objectList);
		}

		private int GetRandomNumber(int min, int max)
		{
			Random random = new Random();
			return random.Next(min, max + 1);
		}

	}
}

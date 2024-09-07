using ExtejProject.SharedModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExtejProject.ApplicationCore.Services.WalletService;

namespace ExtejProject.ApplicationCore.Interfaces
{
	public interface IWalletService
	{
		Task<List<CryptoBalanceResponse>> GetMyCrypto();
		Task<TotalPricesResponse> GetTotalPrices();
		Task<IEnumerable<CryptoInfoResponse>> GetCryptoInformation();
		Task<IEnumerable<CardResponse>> GetMyCards();
		Task<IEnumerable<TransactionResponse>> GetMyTransactions();
	}
}

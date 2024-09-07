using ExtejProject.SharedModels.Responses;

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

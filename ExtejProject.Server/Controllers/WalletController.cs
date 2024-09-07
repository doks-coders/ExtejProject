using ExtejProject.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExtejProject.Server.Controllers
{
	public class WalletController : BaseController
	{
		private readonly IWalletService _walletService;

		public WalletController(IWalletService walletService)
		{
			_walletService = walletService;
		}


		[HttpGet("get-my-crypto")]
		public async Task<ActionResult> GetMyCrypto()
		{
			return Ok(await _walletService.GetMyCrypto());
		}



		[HttpGet("get-my-cards")]
		public async Task<ActionResult> GetMyCards()
		{
			return Ok(await _walletService.GetMyCards());
		}

		[HttpGet("get-total-prices")]
		public async Task<ActionResult> GetTotalPrices()
		{
			return Ok(await _walletService.GetTotalPrices());
		}

		[HttpGet("get-crypto-information")]
		public async Task<ActionResult> GetCryptoInformation()
		{
			return Ok(await _walletService.GetCryptoInformation());
		}

		[HttpGet("get-my-transactions")]
		public async Task<ActionResult> GetMyTransactions()
		{

			return Ok(await _walletService.GetMyTransactions());
		}



	}
}

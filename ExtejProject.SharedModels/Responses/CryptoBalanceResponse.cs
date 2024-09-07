using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtejProject.SharedModels.Responses
{
	
	public class CryptoBalanceResponse
	{
		public string Name { get; set; }
		public double TotalBalance { get; set; } // Crypto in USD
	}
}

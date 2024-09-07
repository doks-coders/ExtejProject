using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtejProject.SharedModels.Responses
{
	public class CryptoInfoResponse
	{
		public string Name { get; set; }
		public string NickName { get; set; }
		public double CurrentPrice { get; set; } // To 1 USD
		public double ChangeRate { get; set; }
		public string RateIntervals { get; set; } // Contains the JSON stringified days and prices
		public double Holdings { get; set; }
	}
}

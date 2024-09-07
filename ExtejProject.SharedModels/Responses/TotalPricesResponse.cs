using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtejProject.SharedModels.Responses
{
	public class TotalPricesResponse
	{
		public double Fiat { get; set; }
		public double Crypto { get; set; }
		public double Total { get; set; }
	}
}

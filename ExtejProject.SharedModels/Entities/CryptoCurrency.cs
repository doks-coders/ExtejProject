﻿namespace ExtejProject.SharedModels.Entities
{
	public class CryptoCurrency : BaseEntity
	{
		public string Name { get; set; }
		public string NickName { get; set; }
		public string RateIntervals { get; set; } //contains the Json stringified days and prices
		public List<Transaction> Transactions { get; set; }
	}
}

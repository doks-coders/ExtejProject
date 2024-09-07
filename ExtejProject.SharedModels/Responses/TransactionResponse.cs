namespace ExtejProject.SharedModels.Responses
{

	public class TransactionResponse
	{
		public string CryptoName { get; set; }
		public double CryptoAmount { get; set; }
		public double Amount { get; set; }
		public string Status { get; set; }
		public string TransactionLink { get; set; }
		public DateTime Created { get; set; }
		public double _24hrRate { get; set; }
		public double _7hrRate { get; set; }
	}

}

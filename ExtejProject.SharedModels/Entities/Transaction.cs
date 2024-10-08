﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExtejProject.SharedModels.Entities
{
	public class Transaction : BaseEntity
	{
		public double CryptoAmount { get; set; }
		public double Amount { get; set; } //USD dollars

		public Guid CryptoId { get; set; }
		[ForeignKey(nameof(CryptoId))]
		[DeleteBehavior(DeleteBehavior.NoAction)]
		public CryptoCurrency Crypto { get; set; }


		public Guid ApplicationUserId { get; set; }
		[ForeignKey(nameof(ApplicationUserId))]
		[DeleteBehavior(DeleteBehavior.NoAction)]
		public ApplicationUser User { get; set; }

		public string Status { get; set; }
		public string TransactionLink { get; set; }

	}
}

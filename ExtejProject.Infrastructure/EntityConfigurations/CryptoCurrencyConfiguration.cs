using ExtejProject.SharedModels.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtejProject.Infrastructure.EntityConfigurations
{
	public class CryptoCurrencyConfiguration : IEntityTypeConfiguration<CryptoCurrency>
	{
		public void Configure(EntityTypeBuilder<CryptoCurrency> builder)
		{
			builder.HasMany(u=>u.Transactions).WithOne(u=>u.Crypto)
				.HasForeignKey(u=>u.CryptoId)
				.OnDelete(DeleteBehavior.NoAction);	
		}
	}
}

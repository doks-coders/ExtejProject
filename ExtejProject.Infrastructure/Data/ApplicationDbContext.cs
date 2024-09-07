using ExtejProject.SharedModels.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ExtejProject.Infrastructure.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		public DbSet<CryptoCurrency> CryptoCurrencies { get; set; }
		public DbSet<Transaction> Transactions { get; set; }
		public DbSet<ApplicationUser> Users { get; set; }
		public DbSet<AccountCard> Cards { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}
	}
}

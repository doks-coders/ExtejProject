using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtejProject.ApplicationCore.Interfaces
{
    public interface ISeedService
    {
		Task SeedCryptoCurrencies();
		Task SeedTransactions();
		Task SeedCards();
		Task SeedUser();

	}
}

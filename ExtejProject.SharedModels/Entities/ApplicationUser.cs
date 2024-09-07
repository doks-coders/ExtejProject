using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtejProject.SharedModels.Entities
{
	public class ApplicationUser:BaseEntity
	{
		public string FullName { get; set; }
		public string JobRole { get; set; }
		public double? AllocatedPrice {  get; set; }	
		public List<Transaction> Transactions { get; set; }
		public List<AccountCard> Cards { get; set; }
	}
}

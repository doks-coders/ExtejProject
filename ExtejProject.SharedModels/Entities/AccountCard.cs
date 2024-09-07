using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtejProject.SharedModels.Entities
{
	public class AccountCard:BaseEntity
	{
		public Guid ApplicationUserId { get; set; }
		public ApplicationUser User { get; set; }	
		public string Name { get; set; }
		public long DebitNumber { get; set; }	
	}
}

/**
 * 
 * Name
DebitNumber
Color

Mastercard : light blue
Visa : o
American Express
Discover Financial


 */
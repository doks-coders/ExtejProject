using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtejProject.SharedModels.Entities
{
	public class BaseEntity
	{
		public Guid Id { get; set; }	
		public DateTime Created { get; set; } = DateTime.UtcNow;
		public bool isDeleted { get; set; } = false;
	}
}

namespace ExtejProject.SharedModels.Entities
{
	public class BaseEntity
	{
		public Guid Id { get; set; }
		public DateTime Created { get; set; } = DateTime.UtcNow;
		public bool isDeleted { get; set; } = false;
	}
}

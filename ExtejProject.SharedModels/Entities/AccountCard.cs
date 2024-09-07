namespace ExtejProject.SharedModels.Entities
{
	public class AccountCard : BaseEntity
	{
		public Guid ApplicationUserId { get; set; }
		public ApplicationUser User { get; set; }
		public string Name { get; set; }
		public long DebitNumber { get; set; }
	}
}

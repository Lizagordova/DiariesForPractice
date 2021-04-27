namespace DiariesForPractice.Persistence.DTO.UDT
{
	public class StaffUdt
	{
		public int Id { get; set; }
		public int OrganizationId { get; set; }
		public string FullName { get; set; }
		public string Job { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
	}
}
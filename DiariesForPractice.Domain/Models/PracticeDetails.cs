namespace DiariesForPractice.Domain.Models
{
	public class PracticeDetails
	{
		public int Id { get; set; }
		public User Student { get; set; }
		public int OrganizationId { get; set; }
		public string ReportingForm { get; set; }
		public string ContractNumber { get; set; }
		public int ResponsibleForStudent { get; set; }
		public int SignsTheContract { get; set; }
	}
}
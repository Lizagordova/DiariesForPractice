namespace DiariesForPractice.Persistence.DTO.UDT
{
	public class PracticeDetailsUdt
	{
		public int Id { get; set; }
		public int StudentId { get; set; }
		public int OrganizationId { get; set; }
		public int ReportingForm { get; set; }
		public string ContractNumber { get; set; }
		public int ResponsibleForStudent { get; set; }
		public int SignsTheContract { get; set; }
	}
}
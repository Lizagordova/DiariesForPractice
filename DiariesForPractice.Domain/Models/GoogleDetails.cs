namespace DiariesForPractice.Domain.Models
{
	public class GoogleDetails
	{
		public int Id { get; set; }
		public int GroupId { get; set; }
		public string SpreadSheetId { get; set; }
		public string SheetName { get; set; }
		public string FirstCell { get; set; }
		public string LastCell { get; set; }
	}
}
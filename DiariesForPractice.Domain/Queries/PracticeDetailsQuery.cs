namespace DiariesForPractice.Domain.Queries
{
	public class PracticeDetailsQuery
	{
		public int? StudentId { get; set; }
		public int? GroupId { get; set; }
		public bool? Generated { get; set; }
		public bool? Send { get; set; }
	}
}
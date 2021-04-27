namespace DiariesForPractice.Domain.Models
{
	public class Group
	{
		public int Id { get; set; }
		public int DirectionId { get; set; }
		public int CourseId { get; set; }
		public string Name { get; set; }
	}
}
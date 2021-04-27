using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ReadModels
{
	[ApiReadModel]
	public class GroupReadModel
	{
		public int Id { get; set; }
		public int DirectionId { get; set; }
		public int CourseId { get; set; }
		public string Name { get; set; }
	}
}
using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ReadModels
{
	[ApiReadModel]
	public class CourseReadModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ViewModels
{
	[ApiViewModel]
	public class CourseViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ReadModels
{
	[ApiReadModel]
	public class StudentsQueryReadModel
	{
		public int InstituteId { get; set; }
		public int CafedraId { get; set; }
		public int DirectionId { get; set; }
		public int GroupId { get; set; }
		public int CourseId { get; set; }
		public int DegreeId { get; set; }
	}
}
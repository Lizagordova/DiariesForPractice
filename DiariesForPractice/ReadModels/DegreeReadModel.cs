using System;
using System.Collections.Generic;
using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ReadModels
{
	[ApiReadModel]
	public class DegreeReadModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public IReadOnlyCollection<CourseReadModel> Courses { get; set; } = Array.Empty<CourseReadModel>();
	}
}
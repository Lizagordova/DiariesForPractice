using System;
using System.Collections.Generic;
using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ViewModels
{
	[ApiViewModel]
	public class DegreeViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public IReadOnlyCollection<CourseViewModel> Courses { get; set; } = Array.Empty<CourseViewModel>();
	}
}
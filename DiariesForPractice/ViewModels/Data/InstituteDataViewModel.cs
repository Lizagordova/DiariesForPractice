using System;
using System.Collections.Generic;
using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ViewModels.Data
{
	[ApiViewModel]
	public class InstituteDataViewModel
	{
		public IReadOnlyCollection<InstituteViewModel> Institutes { get; set; } = Array.Empty<InstituteViewModel>();
		public IReadOnlyCollection<CafedraViewModel> Cafedras { get; set; } = Array.Empty<CafedraViewModel>();
		public IReadOnlyCollection<DirectionViewModel> Directions { get; set; } = Array.Empty<DirectionViewModel>();
		public IReadOnlyCollection<GroupViewModel> Groups { get; set; } = Array.Empty<GroupViewModel>();
		public IReadOnlyCollection<DegreeViewModel> Degrees { get; set; } = Array.Empty<DegreeViewModel>();
		public IReadOnlyCollection<CourseViewModel> Courses { get; set; } = Array.Empty<CourseViewModel>();
	}
}
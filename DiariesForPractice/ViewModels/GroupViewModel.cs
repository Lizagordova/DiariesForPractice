using System;
using System.Collections.Generic;
using DiariesForPractice.Configuration.Typings.Attributes;
using DiariesForPractice.ViewModels.Interfaces;

namespace DiariesForPractice.ViewModels
{
	[ApiViewModel]
	public class GroupViewModel: IInstituteEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int DirectionId { get; set; }
		public int CourseId { get; set; }
		public IReadOnlyCollection<StudentViewModel> Students { get; set; } = Array.Empty<StudentViewModel>();
	}
}
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
		public UserViewModel Responsible { get; set; }
		public IReadOnlyCollection<UserViewModel> Students { get; set; } = Array.Empty<UserViewModel>();
	}
}
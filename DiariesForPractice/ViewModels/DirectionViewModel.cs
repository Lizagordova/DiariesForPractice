using System;
using System.Collections.Generic;
using DiariesForPractice.Configuration.Typings.Attributes;
using DiariesForPractice.ViewModels.Interfaces;

namespace DiariesForPractice.ViewModels
{
	[ApiViewModel]
	public class DirectionViewModel: IInstituteEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int CafedraId { get; set; }
		public IReadOnlyCollection<GroupViewModel> Groups { get; set; } = Array.Empty<GroupViewModel>();
	}
}
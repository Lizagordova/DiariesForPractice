using System;
using System.Collections.Generic;
using DiariesForPractice.Configuration.Typings.Attributes;
using DiariesForPractice.ViewModels.Interfaces;

namespace DiariesForPractice.ViewModels
{
	[ApiViewModel]
	public class CafedraViewModel : IInstituteEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int InstituteId { get; set; }
		public IReadOnlyCollection<DirectionViewModel> Directions { get; set; } = Array.Empty<DirectionViewModel>();
	}
}
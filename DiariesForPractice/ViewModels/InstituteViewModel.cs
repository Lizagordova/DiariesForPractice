using System;
using System.Collections.Generic;
using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ViewModels
{
	[ApiViewModel]
	public class InstituteViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public IReadOnlyCollection<CafedraViewModel> Cafedras { get; set; } = Array.Empty<CafedraViewModel>();
	}
}
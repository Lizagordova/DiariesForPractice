using System;
using System.Collections.Generic;
using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ReadModels
{
	[ApiReadModel]
	public class InstituteReadModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public IReadOnlyCollection<CafedraReadModel> Cafedras { get; set; } = Array.Empty<CafedraReadModel>();
	}
}
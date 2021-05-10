using System;
using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ReadModels
{
	[ApiReadModel]
	public class DiaryReadModel
	{
		public int Id { get; set; }
		public int StudentId { get; set; }
		public string Path { get; set; }
		public bool Generated { get; set; }
		public bool Send { get; set; }
		public DateTime GeneratedDate { get; set; }
		public DateTime PerceivedDate { get; set; }
		public int Completion { get; set; }
		public string Comment { get; set; }
	}
}
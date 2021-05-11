using System;

namespace DiariesForPractice.Domain.Models
{
	public class Diary
	{
		public int Id { get; set; }
		public User Student { get; set; }
		public string Path { get; set; }
		public bool Generated { get; set; }
		public bool Send { get; set; }
		public bool Perceived { get; set; }
		public DateTime SendDate { get; set; }
		public DateTime GeneratedDate { get; set; }
		public DateTime PerceivedDate { get; set; }
		public string Comment { get; set; }
	}
}
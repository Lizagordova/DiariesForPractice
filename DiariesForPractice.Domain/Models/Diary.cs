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
		public DateTime SendTime { get; set; }
		public DateTime PerceivedTime { get; set; }
		public string Comment { get; set; }
	}
}
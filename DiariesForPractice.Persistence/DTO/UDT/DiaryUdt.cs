using System;

namespace DiariesForPractice.Persistence.DTO.UDT
{
	public class DiaryUdt
	{
		public int Id { get; set; }
		public int StudentId { get; set; }
		public string Path { get; set; }
		public bool Generated { get; set; }
		public bool Send { get; set; }
		public bool Perceived { get; set; }
		public DateTime SendTime { get; set; }
		public DateTime PerceivedTime { get; set; }
		public string Comment { get; set; }
	}
}
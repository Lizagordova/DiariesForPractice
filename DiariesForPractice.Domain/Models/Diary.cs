﻿using System;

namespace DiariesForPractice.Domain.Models
{
	public class Diary
	{
		public int Id { get; set; }
		public User Student { get; set; } = new User();
		public string Path { get; set; }
		public bool Generated { get; set; }
		public bool Send { get; set; }
		public bool Perceived { get; set; }
		public bool Approved { get; set; }
		public DateTime SendDate { get; set; } = DateTime.Now;
		public DateTime GeneratedDate { get; set; } = DateTime.Now;
		public DateTime PerceivedDate { get; set; } = DateTime.Now;
		public string Completion { get; set; }
		public string Comment { get; set; }
		public Signatures Signatures { get; set; } = new Signatures();
	}
}
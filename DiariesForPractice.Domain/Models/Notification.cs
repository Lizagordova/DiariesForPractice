using System;

namespace DiariesForPractice.Domain.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
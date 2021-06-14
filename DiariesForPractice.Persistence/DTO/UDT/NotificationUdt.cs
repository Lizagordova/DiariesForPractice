using System;
using DiariesForPractice.Domain.enums;

namespace DiariesForPractice.Persistence.DTO.UDT
{
    public class NotificationUdt
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public int Type { get; set; }
    }
}
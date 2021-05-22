using System;
using DiariesForPractice.Domain.enums;

namespace DiariesForPractice.Persistence.DTO.UDT
{
    public class LogUdt
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string CustomMessage { get; set; }
        public DateTime Date { get; set; }
        public LogType LogType { get; set; }
    }
}
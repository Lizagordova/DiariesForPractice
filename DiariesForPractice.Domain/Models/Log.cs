using System;
using DiariesForPractice.Domain.enums;
using Microsoft.Extensions.Logging;

namespace DiariesForPractice.Domain.Models
{
    public class Log
    {
        public string Message { get; set; }
        public string CustomMessage { get; set; }
        public DateTime Date { get; set; }
        public LogType LogType { get; set; }
        public LogLevel LogLevel { get; set; }
    }
}
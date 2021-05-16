using System;
using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ViewModels
{
    [ApiViewModel]
    public class NotificationViewModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
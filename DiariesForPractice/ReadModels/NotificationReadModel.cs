using System;
using DiariesForPractice.Configuration.Typings.Attributes;

namespace DiariesForPractice.ReadModels
{
    [ApiReadModel]
    public class NotificationReadModel
    {
         public int Id { get; set; }
         public string Message { get; set; }
         public DateTime Date { get; set; }
    }
}
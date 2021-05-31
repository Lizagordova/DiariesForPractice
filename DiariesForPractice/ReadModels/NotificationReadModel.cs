using System;
using DiariesForPractice.Configuration.Typings.Attributes;
using DiariesForPractice.Domain.enums;

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
using System;
using DiariesForPractice.Domain.enums;

namespace DiariesForPractice.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
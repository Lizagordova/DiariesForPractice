using System;

namespace DiariesForPractice.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Number { get; set; }
    }
}
using System;

namespace DiariesForPractice.Persistence.DTO.UDT
{
    public class OrderUdt
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string Number { get; set; }
    }
}
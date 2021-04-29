using System;

namespace DiariesForPractice.Domain.Queries
{
   public class DiaryQuery
    {
        public bool? Generated { get; set; }
        public bool? Send { get; set; }
        public bool? Perceived { get; set; }
        public DateTime? SendDate { get; set; }
        public DateTime? PerceivedDate { get; set; }
    }
}

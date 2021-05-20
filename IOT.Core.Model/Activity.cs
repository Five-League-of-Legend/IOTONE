using System;

namespace IOT.Core.Model
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Slideshow { get; set; }
        public int State { get; set; }
        public DateTime CreateDate { get; set; }
        public int ActivityTime { get; set; }
    }
}

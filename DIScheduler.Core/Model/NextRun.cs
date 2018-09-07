using System;

namespace DIScheduler.Core.Model
{
    public class NextRun
    {
        public int Id { get; set; }
        public DateTime RunStart { get; set; }
        public DateTime RunComplete { get; set; }
    }
}

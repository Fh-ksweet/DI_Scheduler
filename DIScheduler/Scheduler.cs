using DIScheduler.Interfaces;
using System.Diagnostics;

namespace DIScheduler
{
    public class Scheduler : IScheduler
    {
        public Scheduler()
        { }

        public void PollSapphireQueue()
        {
            EventLog.WriteEntry("DI_Scheduler", "RAN SUCCESSFULLY");
        }
    }
}

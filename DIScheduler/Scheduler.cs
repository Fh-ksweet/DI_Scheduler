using DIScheduler.Core.Interfaces;
using DIScheduler.Interfaces;
using System.Diagnostics;

namespace DIScheduler
{
    public class Scheduler : IScheduler
    {
        private readonly ISapphireService _sapphireService;

        public Scheduler(ISapphireService sapphireService)
        {
            _sapphireService = sapphireService;
        }

        public void PollSapphireQueue()
        {
            EventLog.WriteEntry("DI_Scheduler", _sapphireService.FooRuns());
        }
    }
}

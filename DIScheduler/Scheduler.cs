using DIScheduler.Core.Interfaces;
using DIScheduler.Interfaces;

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
            //Go Check the Last Run Table to see if we have a valid last run date
        }
    }
}

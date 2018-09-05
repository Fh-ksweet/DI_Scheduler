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
            //If Last Run Date is Valid Go ahead and pass to whatever endpoint/service is going to insert in to Queue
            //If Lastrun Date is invalid alert somehow (Sentry/Email/Whatever)
        }
    }
}

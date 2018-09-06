using DIScheduler.Core.Interfaces;
using DIScheduler.Core.Model;
using System.Collections.Generic;

namespace DIScheduler.Core.Services
{
    public class SapphireService : ISapphireService
    {
        private readonly INextRunRepository _nextRunRepository;

        public SapphireService(INextRunRepository nextRunRepository)
        {
            _nextRunRepository = nextRunRepository;
        }

        public IList<NextRun> ListNextRuns()
        {
            return _nextRunRepository.ListNextRuns();
        }
    }
}

using DIScheduler.Core.Data.Contexts;
using DIScheduler.Core.Interfaces;
using DIScheduler.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace DIScheduler.Core.Data
{
    public class NextRunRepository : INextRunRepository
    {
        private readonly SchedulerDbContext _db;

        public NextRunRepository(SchedulerDbContext db)
        {
            _db = db;
        }

        public IList<NextRun> ListNextRuns()
        {
            return _db.NextRuns.ToList();
        }

    }
}

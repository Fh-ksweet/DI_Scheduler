using DIScheduler.Core.Model;
using System.Collections.Generic;

namespace DIScheduler.Core.Interfaces
{
    public interface INextRunRepository
    {
        IList<NextRun> ListNextRuns();
    }
}

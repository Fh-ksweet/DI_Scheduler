﻿using DIScheduler.Core.Model;
using System.Collections.Generic;

namespace DIScheduler.Core.Interfaces
{
    public interface ISapphireService
    {
        IList<NextRun> ListNextRuns();
    }
}

using Scheduler.IoC;
using StructureMap;

namespace DIScheduler.DependencyResolution
{
    public class IoC
    {
        public static IContainer Initialize()
        {
            var container = new Container(c =>
            {
                c.AddRegistry<SchedulerRegistry>();
                c.AddRegistry<MainRegistry>();
            });

            return container;
        }

    }
}

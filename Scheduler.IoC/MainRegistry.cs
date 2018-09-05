using DIScheduler.Core.Interfaces;
using StructureMap;

namespace Scheduler.IoC
{
    public class MainRegistry : Registry
    {
        public MainRegistry()
        {
            Scan(scan =>
            {
                scan.LookForRegistries();
                scan.TheCallingAssembly();
                scan.AssemblyContainingType<ISapphireRepository>(); //Scheduler.Core
                scan.WithDefaultConventions();
            });
        }
    }
}

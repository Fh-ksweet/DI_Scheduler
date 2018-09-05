using DIScheduler.DependencyResolution;
using System.Collections.Generic;
using System.ServiceProcess;

namespace DIScheduler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var container = IoC.Initialize();
            var application = container.GetInstance<Application>();
            application.Run();
        }

        public class Application
        {
            private readonly SchedulerService _schedulerService;

            public Application(SchedulerService schedulerService)
            {
                _schedulerService = schedulerService;
            }

            public void Run()
            {
                var servicesToRun = new List<ServiceBase> { _schedulerService };
                ServiceBase.Run(servicesToRun.ToArray());
            }
        }
    }
}

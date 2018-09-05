using DIScheduler.Core.Interfaces;

namespace DIScheduler.Core.Services
{
    public class SapphireService : ISapphireService
    {
        public string FooRuns()
        {
            return "INJECTION WORKED";
        }
    }
}

using DIScheduler.Interfaces;
using System;
using System.Configuration;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;

namespace DIScheduler
{
    public partial class SchedulerService : ServiceBase
    {
        private bool inProcess = false;
        private readonly IScheduler _scheduler;

        private int PollingInterval
        {
            get
            {
                try
                {
                    string pollInterval = ConfigurationManager.AppSettings["PollingInterval"];
                    return Convert.ToInt32(pollInterval);
                    //EventLog.WriteEntry("DIScheduler", "Pollinterval=" + pollInterval);
                }
                catch
                {
                    return 60000; // 1 Minute
                }
            }
        }

        public SchedulerService(IScheduler scheduler)
        {
            _scheduler = scheduler;
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(PollSapphireQueue));

            //Main thread has to sleep for worker thread to pick up control
            Thread.Sleep(1000);
        }

        private void PollSapphireQueue(object stateInfo)
        {
            try
            {
                while (true)
                {
                    try
                    {
                        inProcess = true;
                        EventLog.WriteEntry("DI Scheduler", "Start");
                        _scheduler.PollSapphireQueue();
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry("DI Scheduler", "Exception " + ex.Message, EventLogEntryType.Error);
                        EventLog.WriteEntry("DI Scheduler", "Inner Exception " + ex.InnerException, EventLogEntryType.Error);
                        EventLog.WriteEntry("DI Scheduler", "stack " + ex.StackTrace, EventLogEntryType.Error);
                    }
                    finally
                    {
                        inProcess = false;
                        EventLog.WriteEntry("DI Scheduler", "Stop");
                        Thread.Sleep(PollingInterval);
                    }
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("DI Scheduler", "Exception" + ex);
            }
        }

        protected override void OnStop()
        {
            if (inProcess == true)
            {
                Thread.Sleep(60000);//1 min
            }
        }
    }
}

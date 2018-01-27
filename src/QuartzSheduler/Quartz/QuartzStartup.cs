using System;
using System.Collections.Specialized;
using Quartz;
using Quartz.Impl;
using QuartzSheduler.Quartz.Jobs;

namespace QuartzSheduler.Quartz
{
    public class QuartzStartup
    {
        private IScheduler _scheduler; // after Start, and until shutdown completes, references the scheduler object


        //public QuartzStartup(IHttpSetting httpSett, IHttpSetting spSets)
        //{
            
        //}


        // starts the scheduler, defines the jobs and the triggers
        public async void Start()
        {
            if (_scheduler != null)
            {
                throw new InvalidOperationException("Already started.");
            }

            //var properties = new NameValueCollection
            //{
            //    // json serialization is the one supported under .NET Core (binary isn't)
            //    ["quartz.serializer.type"] = "json",

            //    // the following setup of job store is just for example and it didn't change from v2
            //  //  ["quartz.jobStore.type"] = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz",
            //  //  ["quartz.jobStore.useProperties"] = "false",
            //  //  ["quartz.jobStore.dataSource"] = "default",
            //  //  ["quartz.jobStore.tablePrefix"] = "QRTZ_",
            // //   ["quartz.jobStore.driverDelegateType"] = "Quartz.Impl.AdoJobStore.SqlServerDelegate, Quartz",
            //   // ["quartz.dataSource.default.provider"] = "SqlServer-41", // SqlServer-41 is the new provider for .NET Core
            ////    ["quartz.dataSource.default.connectionString"] = @"Server=(localdb)\MSSQLLocalDB;Database=Quartz;Integrated Security=true"
            //};

 
            NameValueCollection props = new NameValueCollection
            {
                { "quartz.serializer.type", "binary" }
            };
            var factory = new StdSchedulerFactory(props);
            _scheduler = await factory.GetScheduler();
            await _scheduler.Start();

            var userEmailsJob = JobBuilder.Create<SendUserEmailsJob>()
                .WithIdentity("SendUserEmails", "group1")
                .Build();
            var trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await _scheduler.ScheduleJob(userEmailsJob, trigger);


            //NEXT JOB
            //var adminEmailsJob = JobBuilder.Create<SendAdminEmailsJob>()
            //    .WithIdentity("SendAdminEmails")
            //    .Build();
            //var adminEmailsTrigger = TriggerBuilder.Create()
            //    .WithIdentity("AdminEmailsCron")
            //    .StartNow()
            //    .WithCronSchedule("0 0 9 ? * THU,FRI")
            //    .Build();

            //_scheduler.ScheduleJob(adminEmailsJob, adminEmailsTrigger).Wait();
        }


        // initiates shutdown of the scheduler, and waits until jobs exit gracefully (within allotted timeout)
        public void Stop()
        {
            if (_scheduler == null)
            {
                return;
            }

            // give running jobs 30 sec (for example) to stop gracefully
            if (_scheduler.Shutdown(waitForJobsToComplete: true).Wait(30000))
            {
                _scheduler = null;
            }
            else
            {
                // jobs didn't exit in timely fashion - log a warning...
            }
        }
    }
}
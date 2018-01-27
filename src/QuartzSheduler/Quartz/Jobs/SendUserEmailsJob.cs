using System;
using System.Threading.Tasks;
using Quartz;

namespace QuartzSheduler.Quartz.Jobs
{
    public class SendUserEmailsJob : IJob
    {
        //private readonly HttpBaseExchangeBehavior _beh;
        //public SendUserEmailsJob(HttpBaseExchangeBehavior beh)
        //{
        //    _beh = beh;
        //}


        public async Task Execute(IJobExecutionContext context)
        {
            // an instance of email service can be obtained in different ways, 
            // e.g. service locator, constructor injection (requires custom job factory)
            // IMyEmailService emailService = new MyEmailService();

            // delegate the actual work to email service
            // return emailService.SendUserEmails();
            var g = 5 + 5;


            await Console.Out.WriteLineAsync("HelloJob is executing.");
        }
    }
}
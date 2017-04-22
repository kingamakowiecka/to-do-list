using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using System;
using ToDoList.View;

namespace ToDoList.Cron
{
    public class ItemNotificationScheduler
    {
        private ExceptionHandler exceptionHandler;
        private IScheduler scheduler;
        private IJobFactory jobFactory;

        public ItemNotificationScheduler(IScheduler scheduler, ExceptionHandler exceptionHandler, IJobFactory jobFactory)
        {
            this.scheduler = scheduler;
            this.exceptionHandler = exceptionHandler;
            this.jobFactory = jobFactory;
        }

        public void StartCron()
        {
            try
            {
                scheduler.JobFactory = jobFactory;
                scheduler.Start();

                IJobDetail job = new JobDetailImpl("notificationJob", null, typeof(ItemNotificationJob));
                ITrigger trigger = TriggerBuilder.Create()
                    .WithDailyTimeIntervalSchedule
                    (s => s.WithIntervalInSeconds(10)
                            .OnEveryDay())
                            .Build();

                scheduler.ScheduleJob(job, trigger);
            }
            catch (Exception ex)
            {
                exceptionHandler.HandleException(ex);
            }
        }

        public void StopCron()
        {
            scheduler.Shutdown();
        }
    }
}

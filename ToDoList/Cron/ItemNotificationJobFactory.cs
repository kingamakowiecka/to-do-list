using Quartz.Spi;
using System;
using Quartz;

namespace ToDoList.Cron
{
    public class ItemNotificationJobFactory : IJobFactory
    {
        private ItemNotificationJob itemNotificationJob;

        public ItemNotificationJobFactory(ItemNotificationJob itemNotificationCron)
        {
            this.itemNotificationJob = itemNotificationCron;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return itemNotificationJob;
        }

        public void ReturnJob(IJob job)
        {
        }
    }
}

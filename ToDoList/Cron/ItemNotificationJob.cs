using Quartz;
using System.Windows;
using ToDoList.Entity;
using ToDoList.Repository;

namespace ToDoList.Cron
{
    public class ItemNotificationJob : IJob
    {
        private IItemNotificationRepository itemNotificationRepository;

        public ItemNotificationJob(IItemNotificationRepository itemNotificationRepository)
        {
            this.itemNotificationRepository = itemNotificationRepository;
        }

        public void Execute(IJobExecutionContext context)
        {
            MessageBoxResult result = MessageBox.Show("Cron Test", "Item notification", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

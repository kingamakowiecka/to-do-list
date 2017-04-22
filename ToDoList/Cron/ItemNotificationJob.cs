using Quartz;
using System;
using System.Collections.Generic;
using System.Windows;
using ToDoList.Entity;
using ToDoList.Repository;
using ToDoList.View;

namespace ToDoList.Cron
{
    public class ItemNotificationJob : IJob
    {
        private IItemNotificationRepository itemNotificationRepository;
        private ExceptionHandler exceptionHandler;

        public ItemNotificationJob(IItemNotificationRepository itemNotificationRepository, ExceptionHandler exceptionHandler)
        {
            this.itemNotificationRepository = itemNotificationRepository;
            this.exceptionHandler = exceptionHandler;
        }

        public void Execute(IJobExecutionContext context)
        {
            DateTime date = DateTime.Now;
            date.AddTicks(-(date.Ticks % TimeSpan.TicksPerSecond));

            List<ItemNotification> notifications = itemNotificationRepository.FindNotNotifiedByNotificationDate(DateTime.Now);

            foreach (ItemNotification notification in notifications)
            {
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    NotificationWindow notificationWindow = new NotificationWindow()
                    {
                        SelectedItem = notification.Item
                    };

                    try
                    {
                        notification.Notified = true;
                        itemNotificationRepository.Update(notification);
                        notificationWindow.ShowDialog();
                    }
                    catch(Exception ex)
                    {
                        exceptionHandler.HandleException(ex);
                    }
                }));
            }
        }
    }
}

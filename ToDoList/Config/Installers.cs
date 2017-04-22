using Castle.MicroKernel.Registration;
using ToDoList.Controller;
using ToDoList.View;
using ToDoList.Repository;
using ToDoList.Cron;
using Quartz.Spi;
using Quartz;
using Quartz.Impl;

namespace ToDoList.Setup
{
    public class Installers : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(Component.For<ItemController>());
            container.Register(Component.For<ItemNotificationController>());
            container.Register(Component.For<ExceptionHandler>());
            container.Register(Component.For<IItemRepository>().ImplementedBy<ItemRepository>());
            container.Register(Component.For<IItemNotificationRepository>().ImplementedBy<ItemNotificationRepository>());
            container.Register(Component.For<ItemsDbContext>());
            container.Register(Component.For<Shell>());
            container.Register(Component.For<MainWindow>().LifestyleTransient());
            container.Register(Component.For<NotificationWindow>().LifestyleTransient());
            container.Register(Component.For<ISchedulerFactory>().ImplementedBy<StdSchedulerFactory>());
            container.Register(Component.For<IScheduler>().UsingFactory((ISchedulerFactory factory) => factory.GetScheduler()));
            container.Register(Component.For<IJobFactory>().ImplementedBy<ItemNotificationJobFactory>());
            container.Register(Component.For<ItemNotificationScheduler>());
            container.Register(Component.For<ItemNotificationJob>().LifestyleTransient());
        }
    }
}

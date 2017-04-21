﻿using Castle.MicroKernel.Registration;
using ToDoList.Controller;
using ToDoList.View;
using ToDoList.Repository;

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
        }
    }
}

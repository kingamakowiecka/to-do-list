using Castle.Windsor;
using Castle.Windsor.Installer;
using System.Windows;
using ToDoList.View;

namespace ToDoList
{
    public partial class App : Application
    {
        private IWindsorContainer container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            container = new WindsorContainer();
            container.Install(FromAssembly.This());

            var start = container.Resolve<IShell>();
            start.Run();

            container.Release(start);
        }
    }
}

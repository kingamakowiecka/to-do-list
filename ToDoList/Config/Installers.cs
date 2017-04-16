using Castle.MicroKernel.Registration;

namespace ToDoList.Setup
{
    public class Installers : IWindsorInstaller
    {

        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(Component.For<Controller.ItemController>());
            container.Register(Component.For<Repository.ItemRepository>());
            container.Register(Component.For<View.IShell>().ImplementedBy<View.Shell>());
            container.Register(Component.For<MainWindow>().LifestyleTransient());
        }
    }
}

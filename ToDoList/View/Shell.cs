namespace ToDoList.View
{
    public class Shell : IShell
    {
        private MainWindow window;

        public Shell(MainWindow window)
        {
            this.window = window;
        }

        public void Run()
        {
            window.Show();
        }
    }
}

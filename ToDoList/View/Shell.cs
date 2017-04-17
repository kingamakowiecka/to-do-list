namespace ToDoList.View
{
    public class Shell
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

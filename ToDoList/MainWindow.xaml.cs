using System;
using System.Windows;
using ToDoList.Controller;

namespace ToDoList
{
    public partial class MainWindow : Window
    {
        private ItemController itemController;

        public MainWindow(ItemController itemController)
        {
            this.itemController = itemController;
            InitializeComponent();
            DataContext = itemController.GetItems();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }
    }
}

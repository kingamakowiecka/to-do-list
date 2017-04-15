using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using ToDoList.Controller;
using ToDoList.Entity;

namespace ToDoList
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Item> ItemList { get; set; }
        private ItemController itemController;
        private static object syncLock = new object();

        public MainWindow(ItemController itemController)
        {
            InitializeComponent();
            this.itemController = itemController;
            ItemList = new ObservableCollection<Item>();
            BindingOperations.EnableCollectionSynchronization(ItemList, syncLock);
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Item item in itemController.GetItems())
            {
                ItemList.Add(item);
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        private void ClickSaveBtn(object sender, RoutedEventArgs e)
        {
            DataGrid1.CommitEdit();
            Item newItem = ((Button)sender).DataContext as Item;
            itemController.AddItem(newItem);
        }
    }
}

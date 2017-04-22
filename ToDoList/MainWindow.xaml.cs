using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using ToDoList.Controller;
using ToDoList.Entity;
using ToDoList.View;

namespace ToDoList
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Item> ItemList { get; set; }
        private ItemController itemController;
        private ExceptionHandler excpetionHandler;
        private NotificationWindow notificationWindow;
        private static object syncLock = new object();

        public MainWindow(ItemController itemController, ExceptionHandler excpetionHandler, NotificationWindow notificationWindow)
        {
            this.itemController = itemController;
            this.excpetionHandler = excpetionHandler;
            this.notificationWindow = notificationWindow;

            InitializeComponent();
            ItemList = new ObservableCollection<Item>();
            BindingOperations.EnableCollectionSynchronization(ItemList, syncLock);
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime date = (DateTime)SearchDate.SelectedDate;
            GetItemsList(itemController.GetItemsByDate(date));
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        private void ClickSaveBtn(object sender, RoutedEventArgs e)
        {
            DataGrid1.CommitEdit();
            try
            {
                itemController.SaveItem(((Button)sender).DataContext as Item);
                GetItemsList(itemController.GetItemsByDate((DateTime)SearchDate.SelectedDate));
            }
            catch (Exception ex)
            {
                excpetionHandler.HandleException(ex);
            }
        }

        private void ClickDeleteBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                itemController.DeleteItem(((Button)sender).DataContext as Item);
                GetItemsList(itemController.GetItemsByDate((DateTime)SearchDate.SelectedDate));
            }
            catch (Exception ex)
            {
                excpetionHandler.HandleException(ex);
            }
        }

        private void ClickSelectBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                GetItemsList(itemController.GetItemsByDate((DateTime)SearchDate.SelectedDate));
            }
            catch (Exception ex)
            {
                excpetionHandler.HandleException(ex);
            }
        }

        private void ClickNotificationBtn(object sender, RoutedEventArgs e)
        {
            notificationWindow.SelectedItem = (Item)DataGrid1.SelectedItem;
            notificationWindow.Show();
        }

        private void GetItemsList(List<Item> items)
        {
            ItemList.Clear();
            foreach (Item item in items)
            {
                ItemList.Add(item);
            }
        }
    }
}

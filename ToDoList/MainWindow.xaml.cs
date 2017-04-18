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
        private static object syncLock = new object();

        public MainWindow(ItemController itemController, ExceptionHandler excpetionHandler)
        {
            this.itemController = itemController;
            this.excpetionHandler = excpetionHandler;

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
            Item newItem = ((Button)sender).DataContext as Item;
            try
            {
                itemController.SaveItem(newItem);
                GetItemsList(itemController.GetItemsByDate((DateTime)SearchDate.SelectedDate));
            }
            catch (Exception ex)
            {
                String errorMessage = excpetionHandler.HandleException(ex);
                MessageBoxResult result = MessageBox.Show(errorMessage, "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClickDeleteBtn(object sender, RoutedEventArgs e)
        {
            Item item = ((Button)sender).DataContext as Item;
            itemController.DeleteItem(item);
            GetItemsList(itemController.GetItemsByDate((DateTime)SearchDate.SelectedDate));
        }

        private void ClickSelectBtn(object sender, RoutedEventArgs e)
        {
            GetItemsList(itemController.GetItemsByDate((DateTime)SearchDate.SelectedDate));
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

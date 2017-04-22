using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using ToDoList.Controller;
using ToDoList.Entity;

namespace ToDoList.View
{
    public partial class NotificationWindow : Window
    {
        public Item SelectedItem;
        public ItemNotification SelectedItemNotification;
        private ItemNotificationController itemNotificationController;
        private ExceptionHandler excpetionHandler;

        public NotificationWindow(ItemNotificationController itemNotificationController, ExceptionHandler excpetionHandler)
        {
            this.itemNotificationController = itemNotificationController;
            this.excpetionHandler = excpetionHandler;
            InitializeComponent();
            DataContext = this;
        }

        public void NotificationWindowClosing(object sender, CancelEventArgs e)
        {
            typeof(Window).GetField("_isClosing", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(this, false);
            e.Cancel = true;
            Hide();
        }

        void NotificationWindowActivated(object sender, EventArgs e)
        {
            SelectedItemNotification = null;
            try
            {
                SetupWindowData();
                if (SelectedItemNotification != null)
                {
                    SetUpNotificationControls(SelectedItemNotification.NotifiactionDate, true);
                }
                else
                {
                    SetUpNotificationControls(null, false);
                }
            }
            catch (Exception ex)
            {
                excpetionHandler.HandleException(ex);
            }
        }

        private void SetupWindowData()
        {
            SelectedItemNotification = itemNotificationController.GetItemNotificationByItemId(SelectedItem.Id);
            ItemName.Text = SelectedItem.Name;
            ItemDescription.Text = SelectedItem.Description;
            ItemDate.Text = SelectedItem.Date.ToString();
        }

        private void ClickSaveNotificationBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                itemNotificationController.SaveItemNotification(CreateNewItemNotification());
                MessageBoxResult result = MessageBox.Show("Notification saved successfully", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                excpetionHandler.HandleException(ex);
            }
        }

        private void ClickDeleteNotificationBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                itemNotificationController.DeleteItemNotification(SelectedItemNotification);
                SetUpNotificationControls(null, false);
                MessageBoxResult result = MessageBox.Show("Notification deleted successfully", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                excpetionHandler.HandleException(ex);
            }
        }

        private void SetUpNotificationControls(DateTime? date, Boolean buttonEnabled)
        {
            NotificationDate.Value = date;
            DeleteNotificationBtn.IsEnabled = buttonEnabled;
        }

        private ItemNotification CreateNewItemNotification()
        {
            return new ItemNotification()
            {
                Item = SelectedItem,
                ItemId = SelectedItem.Id,
                NotifiactionDate = NotificationDate.Value
            };
        }
    }
}

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
            this.Hide();
        }

        void NotificationWindowActivated(object sender, EventArgs e)
        {
            try
            {
                ItemNotification itemNotification = itemNotificationController.GetItemNotificationByItemId(SelectedItem.Id);
                ItemName.Text = SelectedItem.Name;
                ItemDescription.Text = SelectedItem.Description;
                ItemDate.Text = SelectedItem.Date.ToString();

                if (itemNotification == null)
                {
                    NotificationDate.Value = SelectedItem.Date;
                }
                else
                {
                    NotificationDate.Value = itemNotification.NotifiactionDate;
                }
            }
            catch (Exception ex)
            {
                String errorMessage = excpetionHandler.HandleException(ex);
                MessageBoxResult result = MessageBox.Show(errorMessage, "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClickSaveNotificationBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                ItemNotification newItem = new ItemNotification()
                {
                    Item = SelectedItem,
                    ItemId = SelectedItem.Id,
                    NotifiactionDate = NotificationDate.Value
                };
                itemNotificationController.SaveItemNotification(newItem);
                MessageBoxResult result = MessageBox.Show("Notification saved successfully", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                String errorMessage = excpetionHandler.HandleException(ex);
                MessageBoxResult result = MessageBox.Show(errorMessage, "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

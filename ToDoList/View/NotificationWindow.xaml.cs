using System;
using System.ComponentModel;
using System.Windows;
using ToDoList.Entity;

namespace ToDoList.View
{

    public partial class NotificationWindow : Window
    {
        public Item SelectedItem;

        public NotificationWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void NotificationWindowClosing(object sender, CancelEventArgs e)
        {
            base.OnClosed(e);
        }

        private void NotificationWindowActivated(object sender, EventArgs e)
        {
            ItemName.Text = SelectedItem.Name;
            ItemDescription.Text = SelectedItem.Description;
            ItemDate.Text = String.Format("{0:yyyy-MM-dd HH:mm}", SelectedItem.Date);
        }
    }
}

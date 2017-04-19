using System;
using System.Collections.ObjectModel;
using System.Windows;
using ToDoList.Entity;

namespace ToDoList.View
{
    public partial class NotificationWindow : Window
    {
        public Item SelectedItem;
        public ObservableCollection<Item> ItemList { get; set; }

        public NotificationWindow()
        {
            InitializeComponent();
            ItemList = new ObservableCollection<Item>();
            DataContext = this;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ItemName.Text = SelectedItem.Name;
            ItemDescription.Text = SelectedItem.Description;
            ItemDate.Text = SelectedItem.Date.ToString();
            NotificationDate.Value = SelectedItem.Date;
            ItemList.Add(SelectedItem);
        }
    }
}

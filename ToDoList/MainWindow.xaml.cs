using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ToDoList.controller;
using ToDoList.entity;
using ToDoList.repository;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ItemRepository itemRepository = new ItemRepository();
        ItemController itemController = new ItemController(itemRepository);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Item> items = itemController.getItems();

            dataGrid1.ItemsSource = items;
            if (dataGrid1.Columns.Count > 0)
            {
                dataGrid1.Columns[dataGrid1.Columns.Count - 1].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
        }

    }
}

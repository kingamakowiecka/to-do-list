using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ToDoList.Controller;
using ToDoList.Entity;
using ToDoList.Repository;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ItemRepositoryImpl itemRepository = new ItemRepositoryImpl();
        private ItemController itemController = new ItemController(itemRepository);
        public ObservableCollection<Item> itemList { get; set; }

        public MainWindow()
        {
            itemList = new ObservableCollection<Item>();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Item item in itemController.getItems())
            {
                itemList.Add(item);
            }
        }
    }
}

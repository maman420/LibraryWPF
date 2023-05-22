using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace LibraryProj
{
    public partial class MainWindow : Window
    {
        private readonly ILibraryService _library;
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(ILibraryService library) : this()
        {
            _library = library;
            foreach (var item in _library.GetAllItems()) // give values to the listbox
            {
                ListBoxItem itemItem = new ListBoxItem()
                {
                    Content = item.Name,
                    FontSize = 26
                };
                listBox.Items.Add(itemItem);
            }
        }
        private void selectBtn_Click(object sender, RoutedEventArgs e) // moving to product page with the item you choose
        {
            if (listBox.SelectedItem != null)
            {
                string name = listBox.SelectedItem.ToString().Trim();
                name = name.Remove(0, name.IndexOf(':') + 2);
                object i = _library.Search(name);
                if (i != null)
                {
                    productPage p = new productPage(i, _library);
                    this.Close();
                    p.Show();
                }
            }
            else
                MessageBox.Show("please choose something");
        }
        private void addBookBtn_Click(object sender, RoutedEventArgs e) // move to adding item(book) page
        {
            addingItem addingItem = new addingItem(true, _library);
            this.Close();
            addingItem.Show();
        }
        private void addJournalBtn_Click(object sender, RoutedEventArgs e) // move to adding item(book) page
        {
            addingItem addingItem = new addingItem(false, _library);
            this.Close();
            addingItem.Show();
        }
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) // sort by - combobox
        {
            string s = comboBox.SelectedItem.ToString();
            s = s.Remove(0, s.IndexOf(':') + 2);
            List<Item> sortedList = new List<Item>();
            try
            {
                List<Item> allItemsInList = _library.GetAllItems();
                switch(s)
                {
                    case "A - Z":
                        sortedList = _library.SortListByName(allItemsInList);
                        break;
                    case "price high to low":
                        sortedList = _library.SortListByPrice(allItemsInList);
                        break;
                    case "most stock":
                        sortedList = _library.SortListByStock(allItemsInList);
                        break;
                }
                listBox.Items.Clear();
                for(int i = 0; i < sortedList.Count; i++)
                {
                    ListBoxItem itemItem = new ListBoxItem()
                    {
                        Content = sortedList[i].Name,
                        FontSize = 26
                    };
                    listBox.Items.Add(itemItem);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void searchBtn_Click(object sender, RoutedEventArgs e) // take input from search box and show in the listbox
        {
            if(_library.Search(searchTextBox.Text) != null)
            {
                listBox.Items.Clear();
                ListBoxItem itemItem = new ListBoxItem()
                {
                    Content = _library.Search(searchTextBox.Text).Name,
                    FontSize = 26
                };
                listBox.Items.Add(itemItem);
            } else
            {
                MessageBox.Show($"we didnt find {searchTextBox.Text}");
            }
        }
    }
}

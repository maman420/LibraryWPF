using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibraryProj
{
    public partial class addingItem : Window
    {
        private readonly ILibraryService _library;
        string category = "";
        bool isBook;
        public addingItem(bool isBook, ILibraryService library)
        {
            InitializeComponent();

            _library = library;

            this.isBook = isBook;
            if (!isBook) // if is journal then hide the isbn
            {
                isbnBox.Visibility = Visibility.Hidden;
                isbnLabel.Visibility = Visibility.Hidden;
            }
            foreach (var i in _library.GetCategories()) // content combo box 
            {
                ComboBoxItem itemItem = new ComboBoxItem()
                {
                    Content = i,
                    FontSize = 26
                };
                categoryComboBox.Items.Add(itemItem);
            }
        }
        private void GoToMain()
        {
            MainWindow addingItem = new MainWindow(_library);
            this.Close();
            addingItem.Show();
        }
        private void backToMainBtn_Click(object sender, RoutedEventArgs e) // back to main page
        {
            GoToMain();
        }
        private void saveChangesBtn_Click(object sender, RoutedEventArgs e) // add the item to the list
        {
            if(nameBox.Text != "" && authorBox.Text != "" && stockBox.Text != "" && descriptionBox.Text != "" && priceBox.Text != "" && category != "")
            {
                if (isBook)
                {
                    _library.AddBook(nameBox.Text, authorBox.Text, stockBox.Text, priceBox.Text, descriptionBox.Text, category);
                    MessageBox.Show("new book added");
                }
                else
                {
                    _library.AddJournal(nameBox.Text, authorBox.Text, stockBox.Text, priceBox.Text, descriptionBox.Text, category);
                    MessageBox.Show("new journal added");
                }
            }
            else
                MessageBox.Show("please fill all fields");
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) // check if numbers fileds are only numbers
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void categoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) // category combobox event
        {
            string s = categoryComboBox.SelectedItem.ToString();
            s = s.Remove(0, s.IndexOf(':') + 2);
            category = s;
        }
    }
}

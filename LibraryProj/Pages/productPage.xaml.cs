using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace LibraryProj
{
    public partial class productPage : Window
    {
        private readonly ILibraryService _library;
        Book _currentBook;
        Journal _currentJournal;
        public productPage(object product)
        {
            InitializeComponent();
            try
            {
                Book item = (Book)product;
                _currentBook = item;
                titleTextBlock.Text = item.Name;
                authorTextBlock.Text = "author: " + item.Author;
                stockTextBlock.Text = "in stock: " + item.Stock;
                isbnTextBlock.Text = $"isbn: {item.Isbn}";
                descriptionTextBlock.Text = $"description: {item.Description}";
                priceTextBlock.Text = $"price: {item.Price}$";

            }
            catch
            {
                Journal item = (Journal)product;
                _currentJournal = item;
                titleTextBlock.Text = item.Name;
                authorTextBlock.Text = "author: " + item.Author;
                stockTextBlock.Text = "in stock: " + item.Stock;
            }
        }
        public productPage(object product, ILibraryService library) : this(product)
        {
            _library = library;
        }
        private void GoToMain()
        {
            MainWindow mainWindow = new MainWindow(_library);
            this.Close();
            mainWindow.Show();
        }
        private void backToMainBtn_Click(object sender, RoutedEventArgs e)
        {
            GoToMain();
        }
        private void removeBtn_Click(object sender, RoutedEventArgs e) // delete this item
        {
            _library.RemoveItem(titleTextBlock.Text);
            GoToMain();
            MessageBox.Show("item removed");
        }
        private void addToStockBtn_Click(object sender, RoutedEventArgs e) // add one to stock
        {
            if(_currentJournal != null)
            {
                _library.UpdateStock(_currentJournal.Name, true, 1);
                stockTextBlock.Text = "in stock: " + _currentJournal.Stock;
            }
            else if(_currentBook != null)
            {
                _library.UpdateStock(_currentBook.Name, true, 1);
                stockTextBlock.Text = "in stock: " + _currentBook.Stock;
            }
        }
        private void removeStockBtn_Click(object sender, RoutedEventArgs e) // remove one from stock
        {
            if (_currentJournal != null)
            {
                _library.UpdateStock(_currentJournal.Name, false, 1);
                stockTextBlock.Text = "in stock: " + _currentJournal.Stock;
            }
            else if (_currentBook != null)
            {
                _library.UpdateStock(_currentBook.Name, false, 1);
                stockTextBlock.Text = "in stock: " + _currentBook.Stock;
            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) // validate field is number
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void discountBtn_Click(object sender, RoutedEventArgs e) // change the price accordingly
        {
            int discount;
            bool shit = int.TryParse(discountTextBox.Text, out discount);
            if(shit && discount < 101 && discount > 0)
            {
                if (_currentJournal != null)
                {
                    priceTextBlock.Text = $"price: {_library.UpdatePrice(_currentJournal.Name, discount)}$";
                }
                else if (_currentBook != null)
                {
                    priceTextBlock.Text = $"price: {_library.UpdatePrice(_currentBook.Name, discount)}$";
                }
            }
        }
    }
}

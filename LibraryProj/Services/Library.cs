using LibraryProj.Data;
using System.Collections.Generic;
using System.Linq;

namespace LibraryProj
{
    public class LibraryService : ILibraryService
    {
        private readonly DataContext _context;
        public LibraryService(DataContext context)
        {
            _context = context;
        }
        public List<string> GetCategories()
        {
            return _context.Categories.Select(c => c.Name).ToList();
        }
        public List<Item> GetAllItems()
        {
            var bookList = _context.Books.ToList();
            var journalList = _context.Journals.ToList();

            var itemList = new List<Item>();
            itemList.AddRange(bookList);
            itemList.AddRange(journalList);

            return itemList;
        }
        public void AddBook(string name, string author, string stock, string price, string description, string category) // add book
        {
            int _price;
            int _stock;
            int.TryParse(price, out _price);
            int.TryParse(stock, out _stock);
            
            var bookCategory = _context.Categories.FirstOrDefault(c => c.Name == category);
            if (bookCategory != null)
            {
                _context.Books.Add(new Book(name, author, _stock, _price, description, bookCategory));
                _context.SaveChanges();
            }
        }
        public void AddBook(string name, string author, int stock, int price, string description, int isbn, string category) // add book with isbn
        {
            var bookCategory = _context.Categories.FirstOrDefault(c => c.Name == category);
            if (bookCategory != null)
            {
                _context.Books.Add(new Book(name, author, stock, price, description, bookCategory ,isbn));
                _context.SaveChanges();
            }
        }
        public void AddJournal(string name, string author, string stock, string price, string description, string category) // add journal
        {
            int _price;
            int _stock;
            int.TryParse(price, out _price);
            int.TryParse(stock, out _stock);

            var bookCategory = _context.Categories.FirstOrDefault(c => c.Name == category);
            if (bookCategory != null)
            {                
                _context.Journals.Add(new Journal(name, author, _stock, _price, description, bookCategory));
                _context.SaveChanges();
            }
        }        
        public void UpdateStock(string name, bool plus, int howMuch) // change the stock 
        {
            var item = Search(name);
            if(item != null)
            {
                if (plus)
                    item.Stock += howMuch;
                else
                    item.Stock -= howMuch;
            }
            _context.SaveChanges();
        }
        public int UpdatePrice(string name, int discount)
        {
            var item = Search(name);

            if (item != null)
            {
                int discountAmount = item.Price / 100 * discount;
                item.Price -= discountAmount;
                _context.SaveChanges();
                return item.Price;
            }

            return -1;
        }
        public void RemoveItem(string itemName) // remove book from list and updating the file too
        {                
            var book = _context.Books.FirstOrDefault(b => b.Name == itemName);
            var journal = _context.Journals.FirstOrDefault(b => b.Name == itemName);

            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
            else if(journal != null)
            {
                _context.Journals.Remove(journal);
                _context.SaveChanges();
            }
        }
        public Item? Search(string name)
        {
            var book = _context.Books.FirstOrDefault(b => b.Name == name);
            var journal = _context.Journals.FirstOrDefault(b => b.Name == name);
            if (book != null)
            {
                return book;
            }
            else if (journal != null)
            {
                return journal;
            }
            return null;
        }
        public List<Item> SortListByName(List<Item> list)
        {
            List<Item> newList = list.OrderBy(item => item.Name).ToList();
            return newList;
        }
        public List<Item> SortListByPrice(List<Item> list)
        {
            List<Item> newList = list.OrderBy(item => item.Price).ToList();
            return newList;
        }
        public List<Item> SortListByStock(List<Item> list)
        {
            List<Item> newList = list.OrderBy(item => item.Stock).ToList();
            return newList;
        }
    }
}

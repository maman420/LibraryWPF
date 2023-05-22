using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LibraryProj
{
    public interface ILibraryService
    {
        public List<string> GetCategories();
        public List<Item> GetAllItems();
        public void AddBook(string name, string author, string stock, string price, string description, string category);
        public void AddBook(string name, string author, int stock, int price, string description, int isbn, string category);
        public void AddJournal(string name, string author, string stock, string price, string description, string category);
        public void UpdateStock(string name, bool plus, int howMuch);
        public int UpdatePrice(string name, int discount);
        public void RemoveItem(string itemName);
        public Item? Search(string name);
        List<Item> SortListByName(List<Item> list);
        List<Item> SortListByPrice(List<Item> list);
        List<Item> SortListByStock(List<Item> list);
    }
}
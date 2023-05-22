using LibraryProj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProj
{
    public class Book : Item
    {
        public int Isbn { get; }
        public Book() { }
        public Book(string name, string author, int stock, int price, string description, Category category) : base(name, author, stock, price, description, category)
        { }
        public Book(string name, string author, int stock, int price, string description, Category category, int isbn) : base(name, author, stock, price, description, category)
        {
            if (isbn.ToString().Length == 13)
                Isbn = isbn;
        }
    }
}

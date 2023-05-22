using LibraryProj.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProj
{
    public abstract class Item
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public Item() { }

        public Item(string name, string author, int stock, int price, string description, Category category)
        {
            Name = name;
            Author = author;
            Stock = stock;
            Price = price;
            Description = description;
            Category = category;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}

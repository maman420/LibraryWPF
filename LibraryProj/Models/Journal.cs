using LibraryProj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProj
{
    public class Journal : Item
    {
        public int Issn { get; set; }
        public Journal() { }

        public Journal(string name, string author, int stock, int price, string description, Category category) : base(name, author, stock, price, description, category) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Book
        
    {
        public enum Types { fantasy, criminal, adventure, biography, history }
        public string Author{ get; set; }
        public int Number { get; set; }
        public Types Type { get; set; }
        public string Title { get; set; }

        public Book() { }

      

        public Book(string author, int number, Types type, string title)
        {
            Author = author;
            this.Number = number;
            this.Type = type;
            this.Title = title;
        }

       
    }
}
